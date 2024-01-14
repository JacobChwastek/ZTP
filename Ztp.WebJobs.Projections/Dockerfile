FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Ztp.WebJobs.Projections/Ztp.WebJobs.Projections.csproj", "Ztp.WebJobs.Projections/"]
RUN dotnet restore "Ztp.WebJobs.Projections/Ztp.WebJobs.Projections.csproj"
COPY . .
WORKDIR "/src/Ztp.WebJobs.Projections"
RUN dotnet build "Ztp.WebJobs.Projections.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Ztp.WebJobs.Projections.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ztp.WebJobs.Projections.dll"]
