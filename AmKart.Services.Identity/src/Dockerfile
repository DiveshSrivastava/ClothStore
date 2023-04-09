#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AmKart.Services.Identity/src/AmKart.Services.Identity.csproj", "AmKart.Services.Identity/src/"]
COPY ["AmKart.Common/AmKart.Common.csproj", "AmKart.Common/"]
RUN dotnet restore "AmKart.Services.Identity/src/AmKart.Services.Identity.csproj"
COPY . .
WORKDIR "/src/AmKart.Services.Identity/src"
RUN dotnet build "AmKart.Services.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AmKart.Services.Identity.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AmKart.Services.Identity.dll"]