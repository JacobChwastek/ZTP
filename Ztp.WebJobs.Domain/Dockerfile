FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Ztp.WebJobs.Domain/Ztp.WebJobs.Domain.csproj", "Ztp.WebJobs.Domain/"]
RUN dotnet restore "Ztp.WebJobs.Domain/Ztp.WebJobs.Domain.csproj"
COPY . .
WORKDIR "/src/Ztp.WebJobs.Domain"
RUN dotnet build "Ztp.WebJobs.Domain.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Ztp.WebJobs.Domain.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ztp.WebJobs.Domain.dll"]
