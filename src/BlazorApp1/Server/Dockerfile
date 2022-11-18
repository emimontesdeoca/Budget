#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/BlazorApp1/Server/BlazorApp1.Server.csproj", "src/BlazorApp1/Server/"]
COPY ["src/BlazorApp1/Client/BlazorApp1.Client.csproj", "src/BlazorApp1/Client/"]
COPY ["src/BlazorApp1/Shared/BlazorApp1.Shared.csproj", "src/BlazorApp1/Shared/"]
RUN dotnet restore "src/BlazorApp1/Server/BlazorApp1.Server.csproj"
COPY . .
WORKDIR "/src/src/BlazorApp1/Server"
RUN dotnet build "BlazorApp1.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorApp1.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorApp1.Server.dll"]