# Step 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

# Copy solution file and project files
COPY backend/NeftchiLLCSolution/NeftchiLLCSolution.sln ./
COPY backend/NeftchiLLCSolution/NeftchiLLC.*/*.csproj ./NeftchiLLC.*./

# Restore dependencies
RUN for d in NeftchiLLC.*; do dotnet restore "$d"; done

# Copy all backend source files
COPY backend/NeftchiLLCSolution/. ./

# ✅ Copy frontend built files (must run npm run build manually beforehand)
COPY frontend/dist ./NeftchiLLC.Api/wwwroot

# Build and publish backend
RUN dotnet publish NeftchiLLC.Api/NeftchiLLC.Api.csproj -c Release -o /app/publish

# Step 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "NeftchiLLC.Api.dll"]
