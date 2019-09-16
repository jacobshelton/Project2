FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS buildstage
WORKDIR /aspnet
COPY ["GroupBox.Client/GroupBox.Client.csproj", "GroupBox.Client/"]
RUN dotnet restore GroupBox.Client/GroupBox.Client.csproj
COPY . .
WORKDIR /aspnet/GroupBox.Client
RUN dotnet build GroupBox.Client.csproj

FROM buildstage AS publishstage
RUN dotnet publish GroupBox.Client.csproj --no-restore -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /deploy
COPY --from=publishstage /app .
CMD ["dotnet", "GroupBox.Client.dll"]