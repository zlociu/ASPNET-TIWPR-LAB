FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source
COPY . ./
# WORKDIR /source/aspnetapp
# copy everything else and build app
RUN dotnet publish -c release -o out

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
ENV ASPNETCORE_URLS=http://*:5000
WORKDIR /ASPNET-TIWPR-LAB
COPY --from=build /source/out .
ENTRYPOINT ["dotnet", "Zajecia_ASPNET.dll"]
