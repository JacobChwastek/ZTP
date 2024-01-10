FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Ztp.Api/Ztp.Api.csproj", "Ztp.Api/"]
COPY ["Ztp.Infrastructure/Ztp.Infrastructure.csproj", "Ztp.Infrastructure/"]
COPY ["Ztp.Application/Ztp.Application.csproj", "Ztp.Application/"]
COPY ["Ztp.Domain/Ztp.Domain.csproj", "Ztp.Domain/"]
COPY ["Ztp.Shared.Abstractions/Ztp.Shared.Abstractions.csproj", "Ztp.Shared.Abstractions/"]
COPY ["Ztp.Shared/Ztp.Shared.csproj", "Ztp.Shared/"]
RUN dotnet restore "Ztp.Api/Ztp.Api.csproj"
COPY . .
WORKDIR "/src/Ztp.Api"
RUN dotnet build "Ztp.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Ztp.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ztp.Api.dll"]
