FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Ecommerce_PhuongNam_v1.API/Ecommerce_PhuongNam_v1.API.csproj", "Ecommerce_PhuongNam_v1.API/"]
RUN dotnet restore "Ecommerce_PhuongNam_v1.API/Ecommerce_PhuongNam_v1.API.csproj"
COPY . .
WORKDIR "/src/Ecommerce_PhuongNam_v1.API"
RUN dotnet build "Ecommerce_PhuongNam_v1.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ecommerce_PhuongNam_v1.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ecommerce_PhuongNam_v1.API.dll"]
