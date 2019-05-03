#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-nanoserver-1809 AS build
WORKDIR /src
COPY ["VS2019TestCore/VS2019TestCore.csproj", "VS2019TestCore/"]
RUN dotnet restore "VS2019TestCore/VS2019TestCore.csproj"
COPY . .
WORKDIR "/src/VS2019TestCore"
RUN dotnet build "VS2019TestCore.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "VS2019TestCore.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "VS2019TestCore.dll"]