#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["EnergymApp/EnergymApp.csproj", "EnergymApp/"]
COPY ["EnergymApp.API.Aplicacion.Servicios/EnergymApp.API.Aplicacion.Servicios.csproj", "EnergymApp.API.Aplicacion.Servicios/"]
COPY ["EnergymApp.API.Infraestructura/EnergymApp.API.Infraestructura.csproj", "EnergymApp.API.Infraestructura/"]
COPY ["EnergymApp.API.Aplicacion/EnergymApp.API.DTO.csproj", "EnergymApp.API.Aplicacion/"]
COPY ["EnergymApp.API.Domino/EnergymApp.API.Dominio.csproj", "EnergymApp.API.Domino/"]
RUN dotnet restore "EnergymApp/EnergymApp.csproj"
COPY . .
WORKDIR "/src/EnergymApp"
RUN dotnet build "EnergymApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EnergymApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EnergymApp.dll"]