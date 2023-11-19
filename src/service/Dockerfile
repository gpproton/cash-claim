FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0-jammy AS build
ARG TARGETARCH
ARG configuration=Release
USER app
WORKDIR /src
COPY . .
RUN dotnet restore -a $TARGETARCH "src/service/XClaim.Service.csproj"
WORKDIR "/src/src/service"
RUN dotnet workload restore "XClaim.Service.csproj"
RUN dotnet build "XClaim.Service.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "XClaim.Service.csproj" -c $configuration --no-restore -a $TARGETARCH -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0-jammy-chiseled
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 8080
EXPOSE 443
ENTRYPOINT ["./x-claim"]
