FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY Org.csproj .
RUN dotnet restore "Org.csproj"
COPY . .
RUN dotnet publish "Org.csproj" -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:3.1 as final
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT [ "dotnet", "Org.dll" ]
EXPOSE 5000