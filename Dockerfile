# Step 1: Build .NET and React
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Install Node.js
RUN curl -fsSL https://deb.nodesource.com/setup_18.x | bash - \
    && apt-get install -y nodejs

WORKDIR /src

# Copy backend
COPY backend/NeftchiLLCSolution/NeftchiLLCSolution.sln ./
COPY backend/NeftchiLLCSolution/NeftchiLLC.*/*.csproj ./NeftchiLLC.*./
RUN for d in NeftchiLLC.*; do dotnet restore "$d"; done
COPY backend/NeftchiLLCSolution/. ./

# Copy and build frontend
COPY frontend ./frontend
WORKDIR /src/frontend
RUN npm install && npm run build

# Go back and publish backend
WORKDIR /src
RUN dotnet publish NeftchiLLC.Api/NeftchiLLC.Api.csproj -c Release -o /app/out

# Copy frontend build into wwwroot
RUN cp -r /src/frontend/dist /app/out/wwwroot

# Step 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "NeftchiLLC.Api.dll"]
