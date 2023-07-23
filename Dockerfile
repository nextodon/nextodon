FROM mcr.microsoft.com/dotnet/aspnet:8.0-preview AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0-preview AS build
WORKDIR /src
COPY . .
RUN dotnet restore "Nextodon/Nextodon.csproj"
WORKDIR "/src/Nextodon"
RUN dotnet build "Nextodon.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Nextodon.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Nextodon.dll"]
