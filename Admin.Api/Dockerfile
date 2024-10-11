#Serve Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
ENV ASPNETCORE_ENVIRONMENT=Development
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

#Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURETION=release
WORKDIR /src
COPY ["Admin.Api.csproj","."]
RUN dotnet restore "Admin.Api.csproj" 
COPY . .
WORKDIR "/src"
RUN dotnet build "Admin.Api.csproj" -c $BUILD_CONFIGURETION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURETION=Release
RUN dotnet publish "Admin.Api.csproj" -c $BUILD_CONFIGURETION -o /app/publish /p:UseAppHost=false


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Admin.Api.dll"]