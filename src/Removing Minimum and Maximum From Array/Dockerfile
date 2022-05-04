FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Removing Minimum and Maximum From Array/Removing Minimum and Maximum From Array.csproj", "Removing Minimum and Maximum From Array/"]
RUN dotnet restore "src/Removing Minimum and Maximum From Array/Removing Minimum and Maximum From Array.csproj"
COPY . .
WORKDIR "/src/Removing Minimum and Maximum From Array"
RUN dotnet build "Removing Minimum and Maximum From Array.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Removing Minimum and Maximum From Array.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Removing Minimum and Maximum From Array.dll"]
