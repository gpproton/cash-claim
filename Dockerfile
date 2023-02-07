FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine as base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /src
COPY . .
RUN dotnet restore src/Web/XClaim.Web.sln
RUN dotnet build -c Release src/Web/Server/XClaim.Web.Server.csproj

FROM build AS publish
RUN dotnet publish src/Web/Server/XClaim.Web.Server.csproj -c Release -o /app/published --self-contained

FROM base as runtime
WORKDIR /app
COPY --from=publish /app/published .
ENTRYPOINT [ "dotnet", "/app/XClaim.Web.Server.dll" ]