FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Palindrome Number/Palindrome Number.csproj", "Palindrome Number/"]
RUN dotnet restore "src/Palindrome Number/Palindrome Number.csproj"
COPY . .
WORKDIR "/src/Palindrome Number"
RUN dotnet build "Palindrome Number.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Palindrome Number.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Palindrome Number.dll"]
