FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
RUN mkdir -p /packages
COPY packages /packages
COPY . .

WORKDIR "/src/Roosevelt.Host.WebApi"
RUN dotnet restore "Roosevelt.Host.WebApi.csproj"
RUN dotnet build "Roosevelt.Host.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Roosevelt.Host.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Roosevelt.Host.WebApi.dll"]
