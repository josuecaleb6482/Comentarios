# Instrucciones para construir la imagen de contenedor
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish ./ApiComentarios/ApiComentarios.WebApi.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "ApiComentarios.WebApi.dll"]