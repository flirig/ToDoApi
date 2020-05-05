FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY ToDoApi.WebApi/*.csproj ./aspnetapp/
WORKDIR /app/aspnetapp
RUN dotnet restore

# copy everything else and build app
COPY ToDoApi.WebApi/ .
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-bionic AS runtime
EXPOSE 80
WORKDIR /app
COPY --from=build /app/aspnetapp/out ./
ENTRYPOINT ["dotnet", "ToDoApi.WebApi.dll"]