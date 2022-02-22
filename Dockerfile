FROM mcr.microsoft.com/dotnet/aspnet:6.0

COPY bin/Release/net6.0/publish/ ASPNET-TIWPR-LAB/
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000
WORKDIR /ASPNET-TIWPR-LAB
ENTRYPOINT ["dotnet", "Zajecia_ASPNET.dll"]

