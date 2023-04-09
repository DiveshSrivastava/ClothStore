#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AmKart.Api.Gateway/src/AmKart.Api.Gateway.csproj", "AmKart.Api.Gateway/src/"]
COPY ["AmKart.Common/AmKart.Common.csproj", "AmKart.Common/"]
RUN dotnet restore "AmKart.Api.Gateway/src/AmKart.Api.Gateway.csproj"
COPY . .
WORKDIR "/src/AmKart.Api.Gateway/src"
RUN dotnet build "AmKart.Api.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AmKart.Api.Gateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AmKart.Api.Gateway.dll"]