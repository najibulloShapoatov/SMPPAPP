FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["smsc.SenderAPI/smsc.SenderAPI.csproj", "smsc.SenderAPI/"]
RUN dotnet restore "smsc.SenderAPI/smsc.SenderAPI.csproj"
COPY . .
WORKDIR "/src/smsc.SenderAPI"
RUN dotnet build "smsc.SenderAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "smsc.SenderAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "smsc.SenderAPI.dll"]
