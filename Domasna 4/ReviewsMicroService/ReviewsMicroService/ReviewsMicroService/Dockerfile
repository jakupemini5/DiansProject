#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ReviewsMicroService/ReviewsMicroService.csproj", "ReviewsMicroService/"]
COPY ["ReviewsMicroService.BLL/ReviewsMicroService.BLL.csproj", "ReviewsMicroService.BLL/"]
COPY ["ReviewsMicroService.DAL/ReviewsMicroService.DAL.csproj", "ReviewsMicroService.DAL/"]
RUN dotnet restore "ReviewsMicroService/ReviewsMicroService.csproj"
COPY . .
WORKDIR "/src/ReviewsMicroService"
RUN dotnet build "ReviewsMicroService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReviewsMicroService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReviewsMicroService.dll"]