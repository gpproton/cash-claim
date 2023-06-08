FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/service/XClaim.Service.csproj", "src/service/"]
COPY ["src/web/components/XClaim.Web.Components.csproj", "src/web/components/"]
COPY ["src/common/http/XClaim.Common.Http.csproj", "src/common/http/"]
COPY ["src/common/shared/XClaim.Common.csproj", "src/common/shared/"]
COPY ["src/web/shared/XClaim.Web.Shared.csproj", "src/web/shared/"]
COPY ["src/common/entity/XClaim.Common.Entity.csproj", "src/common/entity/"]
COPY ["src/common/context/XClaim.Common.Context.csproj", "src/common/context/"]
COPY ["src/migration/mysql/XClaim.Entity.Mysql.csproj", "src/migration/mysql/"]
COPY ["src/migration/postgres/XClaim.Entity.Postgres.csproj", "src/migration/postgres/"]
COPY ["src/migration/sqlite/XClaim.Entity.Sqlite.csproj", "src/migration/sqlite/"]
COPY ["src/web/client/XClaim.Web.Client.csproj", "src/web/client/"]
RUN dotnet restore "src/service/XClaim.Service.csproj"
COPY . .
WORKDIR "/src/src/service"
RUN dotnet build "XClaim.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "XClaim.Service.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "XClaim.Service.dll"]
