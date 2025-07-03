# TodoApp

A clean architecture Todo List application built with ASP.NET Core Web API.

## Tech Stack

- ASP.NET Core 8.0 Web API
- Entity Framework Core
- PostgreSQL
- xUnit

## Architecture

- **Domain** - Business logic and entities
- **Application** - Use cases and interfaces
- **Infrastructure** - Data access and external services
- **WebAPI** - Controllers and presentation layer

## Getting Started

```bash
# Clone repository
git clone <repository-url>
cd TodoApp

# Restore packages
dotnet restore

# Build solution
dotnet build

# Run tests
dotnet test

# Run application
dotnet run --project src/TodoApp.WebAPI
```
