FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FiestaMarketBackend.API/FiestaMarketBackend.API.csproj", "FiestaMarketBackend.API/"]
COPY ["FiestaMarketBackend.Application/FiestaMarketBackend.Application.csproj", "FiestaMarketBackend.Application/"]
COPY ["FiestaMarketBackend.Core/FiestaMarketBackend.Core.csproj", "FiestaMarketBackend.Core/"]
COPY ["FiestaMarketBackend.Infrastructure/FiestaMarketBackend.Infrastructure.csproj", "FiestaMarketBackend.Infrastructure/"]
RUN dotnet restore "./FiestaMarketBackend.API/FiestaMarketBackend.API.csproj"
COPY . .
WORKDIR "/src/FiestaMarketBackend.API"
RUN dotnet build "./FiestaMarketBackend.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FiestaMarketBackend.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FiestaMarketBackend.API.dll"]