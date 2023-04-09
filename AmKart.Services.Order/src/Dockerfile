#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AmKart.Services.Order/src/AmKart.Services.Order.csproj", "AmKart.Services.Order/src/"]
COPY ["AmKart.Common/AmKart.Common.csproj", "AmKart.Common/"]
RUN dotnet restore "AmKart.Services.Order/src/AmKart.Services.Order.csproj"
COPY . .
WORKDIR "/src/AmKart.Services.Order/src"
RUN dotnet build "AmKart.Services.Order.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AmKart.Services.Order.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AmKart.Services.Order.dll"]