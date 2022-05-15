FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine3.11 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine3.11 AS build
WORKDIR /src
COPY ["Take.Api.Challenge.Facades/Take.Api.Challenge.Facades.csproj", "Take.Api.Challenge.Facades/"]
COPY ["Take.Api.Challenge.Models/Take.Api.Challenge.Models.csproj", "Take.Api.Challenge.Models/"]
COPY ["Take.Api.Challenge.Services/Take.Api.Challenge.Services.csproj", "Take.Api.Challenge.Services/"]
COPY ["Take.Api.Challenge/Take.Api.Challenge.csproj", "Take.Api.Challenge/"]

RUN dotnet restore "Take.Api.Challenge/Take.Api.Challenge.csproj"
COPY . .
WORKDIR "/src/Take.Api.Challenge"
RUN dotnet build "Take.Api.Challenge.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Take.Api.Challenge.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Take.Api.Challenge.dll"]