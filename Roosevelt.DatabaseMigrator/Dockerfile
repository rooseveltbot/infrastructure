FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
RUN mkdir -p /packages
COPY packages /packages
COPY . .

WORKDIR "/src/Roosevelt.DatabaseMigrator"
RUN dotnet restore "Roosevelt.DatabaseMigrator.csproj"
RUN dotnet build "Roosevelt.DatabaseMigrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Roosevelt.DatabaseMigrator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Roosevelt.DatabaseMigrator.dll"]
