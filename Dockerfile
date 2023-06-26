FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["AuthServer.Consumer.Worker/AuthServer.Consumer.Worker.csproj", "AuthServer.Consumer.Worker/"]
RUN dotnet restore "AuthServer.Consumer.Worker/AuthServer.Consumer.Worker.csproj"
COPY ["AuthServer.Consumer.Worker/.", "AuthServer.Consumer.Worker/"]
RUN dotnet build "/src/AuthServer.Consumer.Worker/AuthServer.Consumer.Worker.csproj" -c Release -o /app/build

WORKDIR "/src/AuthServer.Consumer.Worker"

FROM build AS publish
RUN dotnet publish "AuthServer.Consumer.Worker.csproj" -c Release -o /app/publish /p:UseAppHost=false --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "AuthServer.Consumer.Worker.dll" ]