#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ENV BuildingDocker true
WORKDIR /src
COPY ["firstlab/firstlab.csproj", "firstlab/"]
RUN dotnet restore "firstlab/firstlab.csproj"
COPY . .
WORKDIR "/src/firstlab"
RUN dotnet build "firstlab.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "firstlab.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet firstlab.dll