FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000
ENV DATABASE_PASSWORD=password
ENV DB_SERVER=localhost
ENV DB_PORT=1433
ENV DB_USER=SA

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
RUN curl -fsSL https://deb.nodesource.com/setup_lts.x | bash -
RUN apt-get install -y nodejs
COPY ["FileSender/FileSender.csproj", "FileSender/"]
RUN dotnet restore "FileSender/FileSender.csproj"
COPY . .
WORKDIR "/src/FileSender"
RUN dotnet build "FileSender.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FileSender.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FileSender.dll"]
