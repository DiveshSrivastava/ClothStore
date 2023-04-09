#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
RUN apt-get update -yq && apt-get upgrade -yq && apt-get install -yq curl git nano
RUN curl -sL https://deb.nodesource.com/setup_12.x | bash - && apt-get install -yq nodejs build-essential

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
RUN apt-get update
RUN apt-get install -y curl
RUN apt-get install -y libpng-dev libjpeg-dev curl libxi6 build-essential libgl1-mesa-glx
RUN curl -sL https://deb.nodesource.com/setup_lts.x | bash -
RUN apt-get install -y nodejs
WORKDIR /src
COPY ["AmKart.UI/src/AmKart.UI.csproj", "AmKart.UI/src/"]
COPY ["AmKart.Common/AmKart.Common.csproj", "AmKart.Common/"]
RUN dotnet restore "AmKart.UI/src/AmKart.UI.csproj"
COPY . .
WORKDIR "/src/AmKart.UI/src"
RUN dotnet build "AmKart.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AmKart.UI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM node:16 AS build-web
WORKDIR /src/ClientApp
COPY ["AmKart.UI/src/ClientApp/package.json", "/src/ClientApp/package.json"]
COPY ["AmKart.UI/src/ClientApp/package-lock.json", "/src/ClientApp/package-lock.json"]
#COPY ./AmKart.UI/src/ClientApp/ /AmKart.UI/src/ClientApp
RUN npm install
COPY ./AmKart.UI/src/ClientApp/ /src/ClientApp
RUN npm ci
RUN npm run build
COPY ./AmKart.UI/src/ClientApp/Images /src/ClientApp/build/Images

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build-web /src/ .
ENTRYPOINT ["dotnet", "AmKart.UI.dll"]