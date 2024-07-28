##See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
#
##Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
##For more information, please see https://aka.ms/containercompat
#
#FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
#WORKDIR /app
#EXPOSE 8080
#EXPOSE 8081
#
#FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#COPY ["Patient/Mercure.Patient.API/Mercure.Patient.API.csproj", "Patient/Mercure.Patient.API/"]
#COPY ["Mercure.Common/Mercure.Common.csproj", "Mercure.Common/"]
#COPY ["Patient/Mercure.Patient.Application/Mercure.Patient.Application.csproj", "Patient/Mercure.Patient.Application/"]
#COPY ["Patient/Mercure.Patient.Infrastructure/Mercure.Patient.Infrastructure.csproj", "Patient/Mercure.Patient.Infrastructure/"]
#COPY ["Patient/Mercure.Patient.Domain/Mercure.Patient.Domain.csproj", "Patient/Mercure.Patient.Domain/"]
#RUN dotnet restore "./Patient/Mercure.Patient.API/Mercure.Patient.API.csproj"
#COPY . .
#WORKDIR "/src/Patient/Mercure.Patient.API"
#RUN dotnet build "./Mercure.Patient.API.csproj" -c %BUILD_CONFIGURATION% -o /app/build
#
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "./Mercure.Patient.API.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Mercure.Patient.API.dll"]


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Mercure.Patient.API.csproj", "./"]
RUN dotnet restore "./Mercure.Patient.API.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Mercure.Patient.API.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "Mercure.Patient.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mercure.Patient.API.dll"]