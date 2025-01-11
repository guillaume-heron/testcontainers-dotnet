# Integration testing in .Net 9 using Testcontainers

This project demonstrates how to perform integration testing in .NET 9 applications using [Testcontainers](https://testcontainers.com), a .NET library that provides lightweight, disposable Docker containers for testing purposes.

## ⚙️ Prerequisites

Before you start, ensure that you have the following installed:

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [Docker Desktop](https://www.docker.com/get-started)
- [Visual Studio](https://visualstudio.microsoft.com/) or any .NET-compatible IDE

## 🔍 Project Overview

This example project demonstrates how to:

- Set up a fully functionnal .NET 9 CRUD Web API.
    - Use minimal API
    - Implement Generic Repository pattern with EF Core
    - Use Docker Compose to define and manage multi-container Docker applications.
    - Expose OpenAPI documentation, making it easy to understand and interact with the services.
- Use Testcontainers to spin up Docker containers during tests.
    - Perform integration tests against the containerized services
    - Configure Github Actions to run integration tests in CI/CD pipeline


## 📁 Project Structure

```plaintext
testcontainers-dotnet/
├── .github
│   └── workflows
│       └── build.yml
├── api
│    ├── src
│    │   ├── TestContainers.Api
│    │   ├── .dockerignore
│    │   ├── docker-compose.debug.yml
│    │   └── docker-compose.yml
│    ├── tests
│    │   ├── TestContainers.IntegrationTests
│    │   └── TestContainers.UnitTests
│    └── TestContainers.sln
├── .gitignore
├── LICENSE
└── README.md
```

## 🚀 Getting started

### Build the API

```bash
dotnet build
```

### Run the API

```bash
docker-compose -f "docker-compose.debug.yml" up -d
```

It will start the services defined in the <code>docker-compose.debug.yml</code> file, including a .Net 9 Web API and a PostgreSQL database, in detached mode, with each service running inside its own Docker container.

### Run all tests

```bash
dotnet test
```

This command will run all defined tests in our solution:

- **Unit tests**
- **Integration tests**, which spin up a PostgreSQL database inside a Docker container using TestContainers

## 🔗 Useful Resources

- [.NET 9 Overview](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-9/overview)
- [Docker Compose](https://docs.docker.com/compose/)
- [Testcontainers](https://testcontainers.com)
- [Github Actions](https://docs.github.com/en/actions)

## ⚖️ License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
