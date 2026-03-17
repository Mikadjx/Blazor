FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["ProjetBlazor/ProjetBlazor.csproj", "ProjetBlazor/"]
RUN dotnet restore "ProjetBlazor/ProjetBlazor.csproj"

COPY . .
WORKDIR "/src/ProjetBlazor"
RUN dotnet publish "ProjetBlazor.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ProjetBlazor.dll"]
