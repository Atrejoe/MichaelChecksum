FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY . ./
RUN dotnet restore
RUN dotnet publish MichaelChecksum -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "MichaelChecksum.dll"]