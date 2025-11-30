FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY HcDentalClinic.csproj .

RUN apt-get update
RUN apt-get --no-install-recommends install -y python3

# RUN dotnet workload install android --version 10.0.100.1
RUN dotnet workload install wasm-tools --disable-parallel
RUN dotnet restore HcDentalClinic.csproj
COPY . .

RUN dotnet build HcDentalClinic.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish HcDentalClinic.csproj -c Release -o /app/publish

FROM docker.io/library/nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf