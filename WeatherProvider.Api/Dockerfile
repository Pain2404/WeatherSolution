FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY WeatherProvider.Api/*.csproj WeatherProvider.Api/
RUN dotnet restore WeatherProvider.Api/WeatherProvider.Api.csproj

COPY . .

WORKDIR /src/WeatherProvider.Api
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "WeatherProvider.Api.dll"]
