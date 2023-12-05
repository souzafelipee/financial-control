#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Infra/FinancialControl.Infra.DbMigrator.Runner/FinancialControl.Infra.DbMigrator.Runner.csproj", "Infra/FinancialControl.Infra.DbMigrator.Runner/"]
COPY ["Infra/FinancialControl.Infra.DbMigrator/FinancialControl.Infra.DbMigrator.csproj", "Infra/FinancialControl.Infra.DbMigrator/"]
RUN dotnet restore "Infra/FinancialControl.Infra.DbMigrator.Runner/FinancialControl.Infra.DbMigrator.Runner.csproj"
COPY . .
WORKDIR "/src/Infra/FinancialControl.Infra.DbMigrator.Runner"
RUN dotnet build "FinancialControl.Infra.DbMigrator.Runner.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FinancialControl.Infra.DbMigrator.Runner.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FinancialControl.Infra.DbMigrator.Runner.dll"]
CMD ["-c Server=host.docker.internal;Database=financial-control;Uid=sa;Pwd=Senha@2023;"]