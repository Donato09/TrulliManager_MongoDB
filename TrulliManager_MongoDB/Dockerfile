#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["TrulliManager_MongoDB/TrulliManager_MongoDB.csproj", "TrulliManager_MongoDB/"]
RUN dotnet restore "TrulliManager_MongoDB/TrulliManager_MongoDB.csproj"
COPY . .
WORKDIR "/src/TrulliManager_MongoDB"
RUN dotnet build "TrulliManager_MongoDB.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TrulliManager_MongoDB.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TrulliManager_MongoDB.dll"]