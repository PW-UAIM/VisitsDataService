#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5003

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["majumi.CarService.VisitsDataService.Model/majumi.CarService.VisitsDataService.Model.csproj", "majumi.CarService.VisitsDataService.Model/"]
COPY ["majumi.CarService.VisitsDataService.Rest/majumi.CarService.VisitsDataService.Rest.csproj", "majumi.CarService.VisitsDataService.Rest/"]
COPY ["majumi.CarService.VisitsDataService.Rest.Model/majumi.CarService.VisitsDataService.Rest.Model.csproj", "majumi.CarService.VisitsDataService.Rest.Model/"]
COPY ["majumi.CarService.VisitsDataService.Rest.Tests/majumi.CarService.VisitsDataService.Rest.Tests.csproj", "majumi.CarService.VisitsDataService.Rest.Tests/"]
RUN dotnet restore "majumi.CarService.VisitsDataService.Rest/majumi.CarService.VisitsDataService.Rest.csproj"
COPY . .
WORKDIR "/src/majumi.CarService.VisitsDataService.Rest"
RUN dotnet build "majumi.CarService.VisitsDataService.Rest.csproj" -c Production -o /app/build

FROM build AS publish
RUN dotnet publish "majumi.CarService.VisitsDataService.Rest.csproj" -c Production -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "majumi.CarService.VisitsDataService.Rest.dll"]