FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

COPY *.sln ./
COPY ./CalculatorApp.Application/*.csproj ./CalculatorApp.Application/
COPY ./CalculatorApp.WebAPI/*.csproj ./CalculatorApp.WebAPI/
COPY ./CalculatorApp.Tests/*.csproj ./CalculatorApp.Tests/
RUN dotnet restore

COPY . ./
RUN dotnet publish ./CalculatorApp.WebAPI/CalculatorApp.WebAPI.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "CalculatorApp.WebAPI.dll"]