# Sử dụng .NET SDK để build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Project(DONOTDELETE).sln", "./"]
COPY ["BusinessObject/BusinessObject.csproj", "BusinessObject/"]
COPY ["WebClient/WebClient.csproj", "WebClient/"]
RUN dotnet restore "WebClient/WebClient.csproj"
COPY . .
WORKDIR "/src/WebClient"
RUN dotnet publish -c Release -o /app/publish

# Sử dụng .NET runtime để chạy ứng dụng
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "WebClient.dll"]