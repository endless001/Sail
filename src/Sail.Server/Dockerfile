FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

# It's important to keep lines from here down to "COPY . ." identical in all Dockerfiles
# to take advantage of Docker's build cache, to speed up local container builds
COPY "Sail.sln" "Sail.sln"

COPY "src/Sail/Sail.csproj" "src/Sail/Sail.csproj"
COPY "src/Sail.Administration/Sail.Administration.csproj" "src/Sail.Administration/Sail.Administration.csproj"
COPY "src/Sail.EntityFramework.Storage/Sail.EntityFramework.Storage.csproj" "src/Sail.EntityFramework.Storage/Sail.EntityFramework.Storage.csproj"
COPY "src/Sail.Server/Sail.Server.csproj" "src/Sail.Server/Sail.Server.csproj"
COPY "src/Sail.Storage/Sail.Storage.csproj" "src/Sail.Storage/Sail.Storage.csproj"

COPY "test/Sail.EntityFramework.Storage/Sail.EntityFramework.Storage.IntegrationTests/Sail.EntityFramework.Storage.IntegrationTests.csproj" "test/Sail.EntityFramework.Storage/Sail.EntityFramework.Storage.IntegrationTests/Sail.EntityFramework.Storage.IntegrationTests.csproj"

COPY "NuGet.config" "NuGet.config"

RUN dotnet restore "Sail.sln"

COPY . .
WORKDIR /src/src/Sail.Server
RUN dotnet publish --no-restore -c Release -o /app
 

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Sail.Server.dll"]