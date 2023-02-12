FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Collections.Web/Collections.Web.csproj", "Collections.Web/"]
COPY ["Collections.Web/Collections.ApplicationCore.csproj", "Collections.ApplicationCore/"]
COPY ["Collections.Infrastructure/Collections.Infrastructure.csproj", "Collections.Infrastructure/"]
COPY ["Collections.Shared/Collections.Shared.csproj", "Collections.Shared/"]
RUN dotnet restore "Collections.Web/Collections.Web.csproj"
COPY . .
WORKDIR "/src/Collections.Web"
RUN dotnet build "Collections.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Collections.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Collections.Web.dll"]
