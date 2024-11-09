# Sử dụng .NET SDK để build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Project(DONOTDELETE).sln", "./"]
COPY ["BusinessObject/BusinessObject.csproj", "BusinessObject/"]
COPY ["WebAPIProject/WebAPIProject.csproj", "WebAPIProject/"]
RUN dotnet restore "WebAPIProject/WebAPIProject.csproj"
COPY . .
WORKDIR "/src/WebAPIProject"
RUN dotnet publish -c Release -o /app/publish

# Sử dụng .NET runtime để chạy ứng dụng
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "WebAPIProject.dll"]