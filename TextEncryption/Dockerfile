FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TextEncryption/TextEncryption.csproj", "TextEncryption/"]
RUN dotnet restore "TextEncryption/TextEncryption.csproj"
COPY . .
WORKDIR "/src/TextEncryption"
RUN dotnet build "TextEncryption.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TextEncryption.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TextEncryption.dll"]