# Step 1: Build .NET and React
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Install Node.js
RUN curl -fsSL https://deb.nodesource.com/setup_18.x | bash - \
    && apt-get install -y nodejs

WORKDIR /src

# Copy solution file
COPY backend/NeftchiLLCSolution/NeftchiLLCSolution.sln ./

# Copy all .csproj files
COPY backend/NeftchiLLCSolution/NeftchiLLC.Api/NeftchiLLC.Api.csproj ./NeftchiLLC.Api/
COPY backend/NeftchiLLCSolution/NeftchiLLC.Application/NeftchiLLC.Application.csproj ./NeftchiLLC.Application/
COPY backend/NeftchiLLCSolution/NeftchiLLC.Domain/NeftchiLLC.Domain.csproj ./NeftchiLLC.Domain/
COPY backend/NeftchiLLCSolution/NeftchiLLC.Repositories/NeftchiLLC.Repositories.csproj ./NeftchiLLC.Repositories/

# Restore
RUN dotnet restore NeftchiLLCSolution.sln

# Copy the rest of the backend source
COPY backend/NeftchiLLCSolution/. .

# Copy and build frontend
COPY frontend ./frontend
WORKDIR /src/frontend
RUN npm install && npm run build

# Go back and publish backend
WORKDIR /src
# Publish API and include built frontend in wwwroot
RUN cp -r /src/frontend/dist ./NeftchiLLC.Api/wwwroot
RUN dotnet publish NeftchiLLC.Api/NeftchiLLC.Api.csproj -c Release -o /app/out

# Step 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "NeftchiLLC.Api.dll"]
