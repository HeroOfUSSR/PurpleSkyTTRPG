FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["PurpleSky.API/PurpleSky.API.csproj", "PurpleSky.API/"]
RUN dotnet restore "PurpleSky.API/PurpleSky.API.csproj"

COPY . .
WORKDIR "/src/PurpleSky.API"

RUN dotnet build "PurpleSky.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PurpleSky.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "PurpleSky.API.dll"]