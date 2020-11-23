#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Pazar.Identity/Pazar.Identity.csproj", "Pazar.Identity/"]
RUN dotnet restore "Pazar.Identity/Pazar.Identity.csproj"
COPY . .
WORKDIR "/src/Pazar.Identity"
RUN dotnet build "Pazar.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pazar.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pazar.Identity.dll"]