# Integration testing in .Net 9 using Testcontainers

This project demonstrates how to perform integration testing in .NET 9 applications using [Testcontainers](https://testcontainers.com), a .NET library that provides lightweight, disposable Docker containers for testing purposes.

## Prerequisites

Before you start, ensure that you have the following installed:

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [Docker Desktop](https://www.docker.com/get-started)
- [Visual Studio](https://visualstudio.microsoft.com/) or any .NET-compatible IDE

## Project Overview

This example project demonstrates how to:

- Set up a simple .NET 9 application for integration testing.
- Use Docker Compose to define and manage multi-container Docker applications.
- Expose OpenAPI documentation, making it easy to understand and interact with the services.
- Use Testcontainers to spin up Docker containers during tests.
- Perform integration tests against the containerized services.

The example will focus on an integration test where a simple .NET API interacts with a PostgreSQL database container using Testcontainers.

## Project Structure

```plaintext
testcontainers-dotnet/
├── src
│   ├── TestContainers.Api
│   └── .dockerignore
│   └── docker-compose.debug.yml
│   └── docker-compose.yml
├── tests
│   ├── TestContainers.IntegrationTests
│   └── TestContainers.UnitTests
├── .gitignore
├── LICENSE
├── README.md
└── TestContainers.sln
```

## Getting started

### Build the API

```bash
dotnet build
```

### Run the API

```bash
docker-compose -f "docker-compose.debug.yml" up -d
```

## Useful Resources

- [.NET 9 Overview](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-9/overview)
- [Docker Compose](https://docs.docker.com/compose/)
- [Testcontainers](https://testcontainers.com)

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
