FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Demo.csproj", "."]
RUN dotnet restore "./Demo.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Demo.csproj" -c Release -o /app/build

FROM build as publish
RUN dotnet publish "Demo.csproj" -c Release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "Demo.dll" ]