FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Pazar.Notifications/Pazar.Notifications.csproj", "Pazar.Notifications/"]
RUN dotnet restore "Pazar.Notifications/Pazar.Notifications.csproj"
COPY . .
WORKDIR "/src/Pazar.Notifications"
RUN dotnet build "Pazar.Notifications.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pazar.Notifications.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pazar.Notifications.dll"]