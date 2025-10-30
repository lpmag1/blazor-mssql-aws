# Dockerfile for a .NET Blazor web app (multi-stage)
# Usage: docker build -t my-blazor-app .
ARG DOTNET_VERSION=9.0

FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION} AS build
WORKDIR /src

# Copy everything and restore/build/publish
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:${DOTNET_VERSION} AS runtime
WORKDIR /app

# Copy published output
COPY --from=build /app . 

# Bind to port 80
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

# Minimal entrypoint: run the first DLL in /app (works for typical dotnet publish output)
RUN printf '%s\n' '#!/bin/sh' 'set -e' 'exec dotnet /app/$(ls /app | grep -m1 "\.dll") "$@"' > /entrypoint.sh && chmod +x /entrypoint.sh
ENTRYPOINT ["/entrypoint.sh"]