#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


FROM node:18.13 AS client
WORKDIR /app 
COPY BookApi/ClientApp .

WORKDIR /app/ClientApp
RUN apt-get update
RUN echo "Node.js version:" && node -v 
RUN npm install -y
RUN npm install -g @angular/cli
RUN echo "npm version:" && npm -v
RUN npm run buildprod


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BookApi/BookApi.csproj", "BookApi/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["DataAccess/DataAccess.csproj", "DataAccess/"]
COPY ["Contract/Contract.csproj", "Contract/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
RUN dotnet restore "BookApi/BookApi.csproj"
COPY . .
WORKDIR "/src/BookApi"
RUN dotnet build "BookApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookApi.csproj" -c Release -o /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=client /app/dist /app/ClientApp/dist
COPY --from=client /app/src /app/ClientApp/src
COPY --from=client /app/node_modules /app/ClientApp/node_modules
ENTRYPOINT ["dotnet", "BookApi.dll"]