FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Spoonbill.Frontend/Spoonbill.Frontend.csproj", "Spoonbill.Frontend/"]
RUN dotnet restore "Spoonbill.Frontend/Spoonbill.Frontend.csproj"
COPY . .
WORKDIR "/src/Spoonbill.Frontend"
RUN dotnet build "Spoonbill.Frontend.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Spoonbill.Frontend.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Spoonbill.Frontend.dll"]
