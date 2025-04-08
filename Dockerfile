# STAGE 1: BUILD DOTNET
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY ./backend/NeftchiLLCSolution/NeftchiLLC.Api/NeftchiLLC.Api.csproj ./
RUN dotnet restore

COPY ./backend/NeftchiLLCSolution ./
RUN dotnet publish -c Release -o out

# FINAL STAGE
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "NeftchiLLC.Api.dll"]