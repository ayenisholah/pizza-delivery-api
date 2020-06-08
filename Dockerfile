FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

ARG BUILDCONFIG=RELEASE
ARG VERSION=1.0.0

COPY DeliveryAPI.csproj /build/

RUN dotnet restore ./build/DeliveryAPI.csproj

COPY . ./build/
WORKDIR /build/
RUN dotnet publish ./DeliveryAPI.csproj -c $BUILDCONFIG -o out /p:Version=$VERSION

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app

COPY --from=build-env /build/out .

ENTRYPOINT ["dotnet", "DeliveryAPI.dll"]