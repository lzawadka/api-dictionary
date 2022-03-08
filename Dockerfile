#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#ENV ASPNETCORE_URLS=https://+:5006;http://+:5005
WORKDIR /app
EXPOSE 80
EXPOSE 433

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Apps/api_dictionary.Api/api_dictionary.Api.csproj", "src/Apps/api_dictionary.Api/"]
COPY ["src/Common/api_dictionary.Infrastructure/api_dictionary.Infrastructure.csproj", "src/Common/api_dictionary.Api.Infrastructure/"]
COPY ["src/Common/api_dictionary.Application/api_dictionary.Application.csproj", "src/Common/api_dictionary.Api.Application/"]
COPY ["src/Common/api_dictionary.Domain/api_dictionary.Domain.csproj", "src/Common/api_dictionary.Api.Domain/"]
RUN dotnet restore "src/Apps/api_dictionary.Api/api_dictionary.Api.csproj"
COPY . .
WORKDIR "src/Apps/api_dictionary.Api"
RUN dotnet build "api_dictionary.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "api_dictionary.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api_dictionary.Api.dll"]