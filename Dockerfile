FROM mcr.microsoft.com/dotnet/sdk:8.0.420 AS build
WORKDIR /src
COPY . .
RUN dotnet restore Template.WebApi.sln
RUN dotnet publish Features/APIs/Template.Api/Template.Api.csproj \
 -c Release -o /app/publish --no-restore
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "Template.Api.dll"]