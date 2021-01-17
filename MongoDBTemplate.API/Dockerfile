#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["MongoDBTemplate.API/MongoDBTemplate.API.csproj", "MongoDBTemplate.API/"]
COPY ["MongoDBTemplate.Core/MongoDBTemplate.Core.csproj", "MongoDBTemplate.Core/"]
COPY ["MongoDBTemplate.Infrastructure/MongoDBTemplate.Infrastructure.csproj", "MongoDBTemplate.Infrastructure/"]
RUN dotnet restore "MongoDBTemplate.API/MongoDBTemplate.API.csproj"
COPY . .
WORKDIR "/src/MongoDBTemplate.API"
RUN dotnet build "MongoDBTemplate.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MongoDBTemplate.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MongoDBTemplate.API.dll"]
