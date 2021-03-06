#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["LibraryApp.Web.Api/LibraryApp.Web.Api.csproj", "LibraryApp.Web.Api/"]
COPY ["LibraryApp.IoC/LibraryApp.IoC.csproj", "LibraryApp.IoC/"]
COPY ["LibraryApp.Data/LibraryApp.Data.csproj", "LibraryApp.Data/"]
COPY ["LibraryApp.Domain/LibraryApp.Domain.csproj", "LibraryApp.Domain/"]
COPY ["LibraryApp.Application/LibraryApp.Application.csproj", "LibraryApp.Application/"]
RUN dotnet restore "LibraryApp.Web.Api/LibraryApp.Web.Api.csproj"
COPY . .
WORKDIR "/src/LibraryApp.Web.Api"
RUN dotnet build "LibraryApp.Web.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LibraryApp.Web.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LibraryApp.Web.Api.dll"]