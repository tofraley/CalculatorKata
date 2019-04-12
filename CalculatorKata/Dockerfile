FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk-alpine AS build
WORKDIR /src
COPY ["AdderKata/AdderKata.csproj" "AdderKata/"]
RUN dotnet restore "AdderKata/AdderKata.csproj"
COPY . .
WORKDIR "/src/AdderKata"
RUN dotnet build "AdderKata.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "AdderKata.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AdderKata.dll"]