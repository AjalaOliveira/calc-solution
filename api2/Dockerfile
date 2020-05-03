FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["api2.csproj", "./"]
RUN dotnet restore "./api2.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "api2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "api2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api2.dll"]
