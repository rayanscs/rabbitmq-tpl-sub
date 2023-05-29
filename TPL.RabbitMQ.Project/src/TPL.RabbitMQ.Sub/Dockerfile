#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/TPL.RabbitMQ.Sub/TPL.RabbitMQ.Sub.csproj", "src/TPL.RabbitMQ.Sub/"]
RUN dotnet restore "src/TPL.RabbitMQ.Sub/TPL.RabbitMQ.Sub.csproj"
COPY . .
WORKDIR "/src/src/TPL.RabbitMQ.Sub"
RUN dotnet build "TPL.RabbitMQ.Sub.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TPL.RabbitMQ.Sub.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TPL.RabbitMQ.Sub.dll"]