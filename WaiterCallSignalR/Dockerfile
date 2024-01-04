FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WaiterCallSignalR/WaiterCallSignalR.csproj", "WaiterCallSignalR/"]
RUN dotnet restore "WaiterCallSignalR/WaiterCallSignalR.csproj"
COPY . .
WORKDIR "/src/WaiterCallSignalR"
RUN dotnet build "WaiterCallSignalR.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WaiterCallSignalR.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WaiterCallSignalR.dll"]
