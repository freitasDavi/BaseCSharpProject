# BUILD IMAGE
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# BUILD STAGE
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
# COPY ["src/CashFlow.Api/CashFlow.Api.csproj", "CashFlow.Api/"]
COPY ["/src", "/app"]
# COPY ["src/CashFlow.Application/CashFlow.Application.csproj", "CashFlow.Application/"]
# COPY ["src/CashFlow.Communication/CashFlow.Communication.csproj", "CashFlow.Communication/"]
# COPY ["src/CashFlow.Domain/CashFlow.Domain.csproj", "CashFlow.Domain/"]
# COPY ["src/CashFlow.Exception/CashFlow.Exception.csproj", "CashFlow.Exception/"]
# COPY ["src/CashFlow.Infrastructure/CashFlow.Infrastructure.csproj", "CashFlow.Infrastructure/"]
# COPY ["src/CashFlow.Application/UseCases/Expenses/Reports/Pdf/Fonts/", "CashFlow.Application/UseCases/Expenses/Reports/Pdf/Fonts/"]
RUN dotnet restore "/app/CashFlow.Api/CashFlow.Api.csproj"
COPY . .
WORKDIR "/src/CashFlow.Api/"
RUN dotnet build "/app/CashFlow.Api/CashFlow.Api.csproj" -c Release -o /app/build

# PUBLISH STAGE
FROM build as publish
RUN dotnet publish "/app/CashFlow.Api/CashFlow.Api.csproj" -c Release -o /app/publish

# FINAL STAGE
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "CashFlow.Api.dll" ]