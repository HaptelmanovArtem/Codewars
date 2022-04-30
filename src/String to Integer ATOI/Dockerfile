FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/String to Integer ATOI/String to Integer ATOI.csproj", "String to Integer ATOI/"]
RUN dotnet restore "src/String to Integer ATOI/String to Integer ATOI.csproj"
COPY . .
WORKDIR "/src/String to Integer ATOI"
RUN dotnet build "String to Integer ATOI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "String to Integer ATOI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "String to Integer ATOI.dll"]
