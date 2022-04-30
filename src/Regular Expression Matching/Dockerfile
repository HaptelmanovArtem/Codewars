FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Regular Expression Matching/Regular Expression Matching.csproj", "Regular Expression Matching/"]
RUN dotnet restore "src/Regular Expression Matching/Regular Expression Matching.csproj"
COPY . .
WORKDIR "/src/Regular Expression Matching"
RUN dotnet build "Regular Expression Matching.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Regular Expression Matching.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Regular Expression Matching.dll"]
