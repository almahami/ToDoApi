FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ToDoApi/ToDoApi.csproj", "ToDoApi/"]
RUN dotnet restore "ToDoApi/ToDoApi.csproj"
COPY . .
WORKDIR "/src/ToDoApi"
RUN dotnet build "ToDoApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToDoApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToDoApi.dll"]
