FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5200
EXPOSE 443
ENV ASPNETCORE_URLS=http://*:5200
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ping/ping.csproj", "ping/"]
RUN dotnet restore "ping/ping.csproj"
COPY . .
WORKDIR "/src/ping"
RUN dotnet build "ping.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ping.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ping.dll"]
