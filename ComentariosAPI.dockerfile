# Instrucciones para construir la imagen de contenedor
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copiar archivos de proyecto y restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar y construir la aplicaci�n
COPY . ./
RUN dotnet publish -c Release -o out

# Instrucciones para ejecutar la aplicaci�n
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "ApiComentarios.WebApi"]