FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source
COPY ./ ./aspnetapp/
WORKDIR /source/aspnetapp
# copy everything else and build app
RUN dotnet publish -c release

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
ENV ASPNETCORE_URLS=http://*:5000
WORKDIR /ASPNET-TIWPR-LAB
COPY --from=build /source/aspnetapp/bin/release/net6.0/publish/ ./
ENTRYPOINT ["dotnet", "Zajecia_ASPNET.dll"]