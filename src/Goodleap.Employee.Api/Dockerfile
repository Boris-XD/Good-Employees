#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Goodleap.Employee.Api/Goodleap.Employee.Api.csproj", "src/Goodleap.Employee.Api/"]
COPY ["src/Goodleap.Employee.Repository/Goodleap.Employee.Core.csproj", "src/Goodleap.Employee.Repository/"]
RUN dotnet restore "src/Goodleap.Employee.Api/Goodleap.Employee.Api.csproj"
COPY . .
WORKDIR "/src/src/Goodleap.Employee.Api"
RUN dotnet build "Goodleap.Employee.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Goodleap.Employee.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Goodleap.Employee.Api.dll"]
