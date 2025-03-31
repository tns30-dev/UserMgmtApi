# UserManagementAPI

## Overview

UserManagementAPI is an ASP.NET Core Web API project designed to manage users with CRUD operations. It includes token-based authentication and middleware for logging and exception handling.

## Features

- **CRUD Operations**: Create, Read, Update, and Delete users.
- **Token-Based Authentication**: Middleware to validate tokens from incoming requests.
- **Logging Middleware**: Logs HTTP requests and responses.
- **Exception Handling Middleware**: Catches unhandled exceptions and returns consistent error responses.

## Getting Started

### Prerequisites

- .NET 6 SDK
- Visual Studio or any other code editor
- Postman or `curl` for testing

### Installation

1. Clone the repository:

    ```bash
    git clone git@github.com:tns30-dev/UserMgmtApi.git
    ```

2. Navigate to the project directory:

    ```bash
    cd UserManagementAPI
    ```

3. Restore the dependencies:

    ```bash
    dotnet restore
    ```

### Configuration

1. Update the `appsettings.json` file with your JWT key:

    ```json
    {
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "Jwt": {
        "Key": "your_secret_key_here"
      },
      "AllowedHosts": "*"
    }
    ```

    **Note:** For marking purposes, ensure that sensitive information such as the JWT key is included in the repository.

### Running the Application

1. Build and run the application:

    ```bash
    dotnet run
    ```

2. The API will be available at `http://localhost:<port_number>`.

### API Endpoints

#### Users

- **GET /api/users**: Retrieve a list of users.
- **GET /api/users/{id}**: Retrieve a specific user by ID.
- **POST /api/users**: Add a new user.
- **PUT /api/users/{id}**: Update an existing user's details.
- **DELETE /api/users/{id}**: Remove a user by ID.

### Testing

Use Postman or `curl` to test the API endpoints. Include the JWT in the `Authorization` header for authenticated requests.

Example `curl` command:

```bash
curl -H "Authorization: Bearer your_secret_key_here" http://localhost:<port_number>/api/users
