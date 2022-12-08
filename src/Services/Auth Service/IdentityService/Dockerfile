#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Auth Service/IdentityService/IdentityService.csproj", "Auth Service/IdentityService/"]
COPY ["Auth Service/Blog.Model/Blog.Model.csproj", "Auth Service/Blog.Model/"]
COPY ["Auth Service/Blog.Data/Blog.Data.csproj", "Auth Service/Blog.Data/"]
RUN dotnet restore "Auth Service/IdentityService/IdentityService.csproj"
COPY . .
WORKDIR "/src/Auth Service/IdentityService"
RUN dotnet build "IdentityService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IdentityService.dll"]