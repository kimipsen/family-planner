## base
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base

EXPOSE 7001
ENV ASPNETCORE_URLS=http://+:7001

## build
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /
COPY *.csproj .
RUN dotnet restore

COPY . .
RUN dotnet build -c Release -p:AssemblyName=App -o /build

## publish
FROM build AS publish
RUN dotnet publish -c Release -p:AssemblyName=App -o /publish

## final
FROM base AS final
WORKDIR /app
COPY --from=publish /publish .

ENTRYPOINT ["dotnet", "App.dll"]
