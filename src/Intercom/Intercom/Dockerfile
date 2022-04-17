FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Intercom/Intercom.csproj", "Intercom/"]
RUN dotnet restore "Intercom/Intercom.csproj"
COPY . .
WORKDIR "/src/Intercom"
RUN dotnet build "Intercom.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Intercom.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Intercom.dll"]
