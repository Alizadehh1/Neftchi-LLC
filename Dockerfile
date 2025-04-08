# Step 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy solution and projects
COPY ./backend/NeftchiLLCSolution/NeftchiLLCSolution.sln ./
COPY ./backend/NeftchiLLCSolution/NeftchiLLC.*/*.csproj ./src/

# Copy all source files
COPY ./backend/NeftchiLLCSolution ./src/

# Restore
WORKDIR /app/src
RUN dotnet restore "../NeftchiLLCSolution.sln"

# Publish
RUN dotnet publish "NeftchiLLC.Api/NeftchiLLC.Api.csproj" -c Release -o /app/out

# Step 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "NeftchiLLC.Api.dll"]
