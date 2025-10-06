# build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ./HundredX.API/*.csproj ./HundredX.API/
RUN dotnet restore ./HundredX.API/HundredX.API.csproj
COPY . .
RUN dotnet publish ./HundredX.API/HundredX.API.csproj -c Release -o /out /p:UseAppHost=false

# runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "HundredX.API.dll"]
