#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["User/Mercure.User.API/Mercure.User.API.csproj", "User/Mercure.User.API/"]
COPY ["Patient/Mercure.Patient.API/Mercure.Patient.API.csproj", "Patient/Mercure.Patient.API/"]
COPY ["User/Mercure.User.Application/Mercure.User.Application.csproj", "User/Mercure.User.Application/"]
COPY ["User/Mercure.User.Domain/Mercure.User.Domain/Mercure.User.Domain.csproj", "User/Mercure.User.Domain/Mercure.User.Domain/"]
COPY ["Mercure.Common/Mercure.Common.csproj", "Mercure.Common/"]
COPY ["User/Mercure.User.Infrastructure/Mercure.User.Infrastructure.csproj", "User/Mercure.User.Infrastructure/"]
RUN dotnet restore "./User/Mercure.User.API/Mercure.User.API.csproj"
COPY . .
WORKDIR "/src/User/Mercure.User.API"
RUN dotnet build "./Mercure.User.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Mercure.User.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mercure.User.API.dll"]