FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MichaelChecksum/MichaelChecksum.csproj", "MichaelChecksum/"]
RUN dotnet restore "MichaelChecksum/MichaelChecksum.csproj"
COPY . .
WORKDIR "/src/MichaelChecksum"
RUN dotnet build "MichaelChecksum.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MichaelChecksum.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MichaelChecksum.dll"]