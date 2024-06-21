FROM mcr.microsoft.com/dotnet/core/sdk:3.1

COPY dist/bundle /app

WORKDIR /app

EXPOSE 8080

ENV ASPNETCORE_URLS=http://*:8080

CMD [ "dotnet",  "Sample.Api.dll"]