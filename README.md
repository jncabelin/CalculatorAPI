# CalculatorApp

## About The Project
This is a simple calculator Web API Application utilizing C# and .NET 6. 

## How to run the project
Swagger UI: `<localhost:port>/swagger/index.html`

**With Docker:**
This will create a container with the application
Make sure that you have Docker installed on your machine & running.
1. Clone the repository
2. In root directory run `docker build . -t <image_name>`
3. After a successful build, run `docker run --name <container_name> -d <image_name> -p <port>:80 `

**Without Docker:**
1. Clone the repository
2. In root directory run `dotnet restore`
3. In root directory run `dotnet build`
4. In root directory run `dotnet run --project ./CalculatorApp.WebAPI/CalculatorApp.WebAPI.csproj `


### Technologies & Features

- [x] ASP.NET Core 6 WebApi
- [x] XUnit with Moq Testing Framework
- [x] REST Standards
- [x] CQRS with MediatR Library
- [x] FluentResults
- [x] Swagger UI

### Endpoints
**Add Numbers**
- `/add-numbers?Addend1=<Type_Addend1_Here>&Addend2=<Type_Addend2_Here>`

**Subtract Numbers**
- `/subtract-numbers?Minuend=<Type_Minuend_Here>&Subtrahend=<Type_Subtrahend_Here>`
- Minuend: number which is subtracted from a given number(subtrahend)

**Multiply Numbers**
- `/multiply-numbers?Multiplicand1=<Type_Multiplicand1_Here>&Multiplicand2=<Type_Multiplicand2_Here>`

**Divide Numbers**
- `/divide-numbers?Dividend=<Type_Dividend_Here>&Divisor=<Type_Divisor_Here>`
- Divisor: number which divides a given number(dividend)

