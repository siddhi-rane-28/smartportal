FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY . .
EXPOSE 10000
ENV ASPNETCORE_URLS=http://+:10000
ENTRYPOINT ["dotnet", "SMARTPORATL.dll"]
