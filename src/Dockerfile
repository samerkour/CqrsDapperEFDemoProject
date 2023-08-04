FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# copy all the layers' csproj files into respective folders
COPY ["./Salary.API/Salary.API.csproj", "src/Salary.API/"]
COPY ["./Salary.Application/Salary.Application.csproj", "src/Salary.Application/"]
COPY ["./Salary.Core/Salary.Core.csproj", "src/Salary.Core/"]
COPY ["./ContainerNinja.Core/ContainerNinja.Core.csproj", "src/ContainerNinja.Core/"]
COPY ["./Salary.InfrastructureSalary.Infrastructure.csproj", "src/Salary.Infrastructure/"]

# run restore over API project - this pulls restore over the dependent projects as well
RUN dotnet restore "src/Salary.API/Salary.API.csproj"

COPY . .

# run build over the API project
WORKDIR "/src/Salary.API/"
RUN dotnet build -c Release -o /app/build

# run publish over the API project
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS runtime
WORKDIR /app

COPY --from=publish /app/publish .
RUN ls -l
ENTRYPOINT [ "dotnet", "Salary.API.dll" ]