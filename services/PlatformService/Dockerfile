
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# copy csproj to get list of all dependencies
COPY *.csproj ./
# pull down all packages
RUN dotnet restore

# copy files over
COPY . ./
# run the pubish build of the service
RUN dotnet publish -c Release -o out

# building full runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0
# create working directory
WORKDIR /app
# copy contents of what we built to image
COPY --from=build-env /app/out .
# tell docker what to run when the image is initialized
ENTRYPOINT [ "dotnet", "PlatformService.dll" ]