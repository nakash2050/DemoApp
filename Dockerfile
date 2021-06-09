### Angular Build
FROM node:10-alpine as ngbuilder
COPY ./weather-app/package.json ./weather-app/package-lock.json ./
RUN npm install && mkdir /ng-app && mv ./node_modules ./ng-app
WORKDIR /ng-app
COPY ./weather-app .
RUN npm run ng build -- --configuration=production --output-path=dist

### .NET Build
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["./API/Demo.csproj", "."]
RUN dotnet restore "./Demo.csproj"
COPY ./API .

### This is where copy happens
COPY --from=ngbuilder /ng-app/dist wwwroot

WORKDIR "/src/."
RUN dotnet build "Demo.csproj" -c Release -o /app/build

FROM build as publish
RUN dotnet publish "Demo.csproj" -c Release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "Demo.dll" ]