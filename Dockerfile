FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY src/HelpDesk.Domain/HelpDesk.Domain.csproj ./src/HelpDesk.Domain/
COPY src/HelpDesk.Application/HelpDesk.Application.csproj ./src/HelpDesk.Application/
COPY src/HelpDesk.Infrastructure/HelpDesk.Infrastructure.csproj ./src/HelpDesk.Infrastructure/
COPY src/HelpDesk.Api/HelpDesk.Api.csproj ./src/HelpDesk.Api/
RUN dotnet restore ./src/HelpDesk.Api/HelpDesk.Api.csproj

COPY . ./
RUN dotnet publish ./src/HelpDesk.Api -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
EXPOSE 5432
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "HelpDesk.Api.dll"]
