FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /app

COPY ./NLayer.Core/*.csproj ./NLayer.Core/ 
COPY ./NLayer.Repository/*.csproj ./NLayer.Repository/ 
COPY ./NLayer.Service/*.csproj ./NLayer.Service/  
COPY ./NLayer.Web/*.csproj ./NLayer.Web/  
COPY *.sln .
RUN dotnet restore
COPY . .
RUN dotnet publish ./NLayer.Web/*.csproj -o /publish/
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /publish .
ENV ASPNETCORE_URLS="http://*:5000"
ENTRYPOINT [ "dotnet","NLayer.Web.dll" ]


