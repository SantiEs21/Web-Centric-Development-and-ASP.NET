# Web-Centric-Development-and-ASP.NET

A Todo REST API built with C# and ASP.NET Core (`TodoApi`). It uses an in-memory database, so **you don't need to install any database**.

## Requirements

- [.NET SDK 10.0](https://dotnet.microsoft.com/download/dotnet/10.0) (the project targets `net10.0`)
- Git
- An editor (optional): VS Code with the C# Dev Kit extension, or Visual Studio 2022+

Check your installation:

```bash
dotnet --version   # should show 10.x
git --version
```

## Installation

```bash
# 1. Clone the repository
git clone <REPOSITORY-URL>
cd Web-Centric-Development-and-ASP.NET

# 2. Restore local tools (CSharpier, optional) and NuGet packages
dotnet tool restore
dotnet restore

# 3. (Optional) Trust the HTTPS development certificate
dotnet dev-certs https --trust
```

> On Linux, `dotnet dev-certs https --trust` does not trust the certificate automatically. Use the `http` profile instead.

## Run the project

```bash
dotnet run --launch-profile https
```

Or HTTP only (same as plain `dotnet run`):

```bash
dotnet run --launch-profile http
```

URLs:

| Profile | URL                    |
| ------- | ---------------------- |
| http    | http://localhost:5088  |
| https   | https://localhost:7216 |

Press `Ctrl + C` to stop the application.

## Test the API

- Swagger UI (Development only): http://localhost:5088/swagger
- OpenAPI document: http://localhost:5088/openapi/v1.json
- The `TodoApi.http` file, to test from VS Code / Visual Studio.

Main endpoints:

| Method | Route                 | Description            |
| ------ | --------------------- | ---------------------- |
| GET    | `/api/TodoItems`      | List todo items        |
| GET    | `/api/TodoItems/{id}` | Get one todo item      |
| POST   | `/api/TodoItems`      | Create a todo item     |
| PUT    | `/api/TodoItems/{id}` | Update a todo item     |
| DELETE | `/api/TodoItems/{id}` | Delete a todo item     |
| GET    | `/weatherforecast`    | Template sample        |

Example:

```bash
curl -X POST http://localhost:5088/api/TodoItems \
  -H "Content-Type: application/json" \
  -d '{"name":"My first task","isComplete":false}'
```

## Useful commands

```bash
dotnet build           # build
dotnet watch run       # run with hot reload
dotnet csharpier .     # format the code
```

> Note: data lives in memory and is lost when the application stops.
