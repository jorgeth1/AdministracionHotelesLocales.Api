# Usa la imagen de SDK de .NET Core para compilar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
EXPOSE 80

# Copiar cada uno de los archivos de proyecto y restaurar las dependencias
COPY *.sln .
COPY AdministracionHotelesLocales.Api/*.csproj ./AdministracionHotelesLocales.Api/
COPY AdministracionHotelesLocales.Domain/*.csproj ./AdministracionHotelesLocales.Domain/
COPY AdministracionHotelesLocales.App/*.csproj ./AdministracionHotelesLocales.App/
COPY AdministracionHotelesLocales.Infra/*.csproj ./AdministracionHotelesLocales.Infra/

RUN dotnet restore AdministracionHotelesLocales.Api/AdministracionHotelesLocales.Api.csproj
RUN dotnet restore AdministracionHotelesLocales.Domain/AdministracionHotelesLocales.Domain.csproj
RUN dotnet restore AdministracionHotelesLocales.App/AdministracionHotelesLocales.App.csproj
RUN dotnet restore AdministracionHotelesLocales.Infra/AdministracionHotelesLocales.Infra.csproj

# Copiar todos los archivos y construye la aplicación
COPY . .
WORKDIR /app/AdministracionHotelesLocales.Api
RUN dotnet build -c Release -o /app/build

# Publicar la aplicación
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

# Usar una imagen de ASP.NET Core mínima para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdministracionHotelesLocales.Api.dll"]
