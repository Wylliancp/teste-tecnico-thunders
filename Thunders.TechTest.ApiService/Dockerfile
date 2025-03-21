FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Thunders.TechTest.ApiService/Thunders.TechTest.ApiService.csproj", "Thunders.TechTest.ApiService/"]
COPY ["Thunders.TechTest.OutOfBox/Thunders.TechTest.OutOfBox.csproj", "Thunders.TechTest.OutOfBox/"]
COPY ["Thunders.TechTest.ServiceDefaults/Thunders.TechTest.ServiceDefaults.csproj", "Thunders.TechTest.ServiceDefaults/"]
RUN dotnet restore "Thunders.TechTest.ApiService/Thunders.TechTest.ApiService.csproj"
COPY . .
WORKDIR "/src/Thunders.TechTest.ApiService"
RUN dotnet build "Thunders.TechTest.ApiService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Thunders.TechTest.ApiService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Thunders.TechTest.ApiService.dll"]
