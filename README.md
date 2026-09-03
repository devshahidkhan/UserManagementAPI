# UserManagementWebAPI

![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-Web%20API-512BD4?style=flat-square\&logo=dotnet\&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=flat-square\&logo=csharp\&logoColor=white)
![JWT](https://img.shields.io/badge/Auth-JWT-black?style=flat-square)
![EF Core](https://img.shields.io/badge/ORM-EF%20Core-512BD4?style=flat-square)
![Swagger](https://img.shields.io/badge/API%20Docs-Swagger-85EA2D?style=flat-square\&logo=swagger\&logoColor=white)
![Serilog](https://img.shields.io/badge/Logging-Serilog-00A98F?style=flat-square)
![License](https://img.shields.io/badge/License-MIT-green?style=flat-square)

A secure and maintainable **RESTful Web API** built with **ASP.NET Core** for managing users. The project demonstrates authentication, authorization, password security, database access, validation, exception handling, structured logging, API documentation, and a layered architecture using interfaces, services, repositories, filters, middleware, and extension methods.

---

## 📖 Overview

**UserManagementWebAPI** is a backend application designed to demonstrate professional ASP.NET Core Web API development beyond basic CRUD operations.

The application provides user registration, authentication, and user management functionality. Passwords are securely hashed and salted before being stored in the database, while authentication is handled using signed JWT access tokens containing user claims and roles.

The project follows a maintainable layered architecture with clear separation of responsibilities between controllers, services, repositories, DTOs, filters, middleware, and data-access components.

Additional features such as **Serilog structured logging**, **Swagger/OpenAPI documentation**, **Fluent validation**, standardized API responses, and reusable extension methods help keep the application organized and extensible.

---

# 🚀 Features

## 🔐 Authentication & Security

* User registration and login
* JWT-based authentication
* JWT tokens signed using **HMAC-SHA512 (HS512)**
* Role-based authorization
* Role claims included in authenticated tokens
* Secure password hashing and unique salts
* Plain-text passwords are never stored
* Token validation including:

  * Signature
  * Issuer
  * Audience
  * Expiration
* Protected API endpoints using ASP.NET Core authorization

---

## 👤 User Management

Complete CRUD functionality for user records:

* Create users
* Retrieve all users
* Retrieve a user by ID
* Update users
* Delete users

API contracts are separated from database entities using **DTOs**, with C# `record` types used where appropriate for concise request/response models.

---

## ⚡ Validation, Filters & Middleware

The project demonstrates several cross-cutting concerns:

### Validation

Validates incoming request data before processing it in the application.

### Exception Handling

Centralized exception handling provides consistent error responses instead of exposing internal implementation details.

### Authorization

Protected endpoints require a valid authenticated user and, where applicable, the required role.

### Custom Middleware

Custom middleware components are used for application-wide concerns that belong in the HTTP request pipeline.

---

## 📝 Logging & API Documentation

### Serilog

Structured application logging is implemented using **Serilog**.

Logging configuration is separated from `Program.cs` through reusable extension methods to keep application startup configuration clean.

### Swagger / OpenAPI

Swagger provides:

* Interactive API documentation
* Endpoint discovery
* Request/response documentation
* API testing directly from the browser
* JWT authorization support for protected endpoints

---

# 🗄️ Database

The application uses:

* **Entity Framework Core**
* **SQL Server**
* EF Core migrations
* `DbContext` for database access
* Configurable connection strings

The repository layer abstracts database operations from the service layer.

---

# 🏛️ Architecture

The application follows a **layered, interface-driven architecture**.

```text
                    Client
                       │
                       ▼
                 ┌───────────┐
                 │ Controller│
                 └─────┬─────┘
                       │
                       ▼
                 ┌───────────┐
                 │  Service  │
                 └─────┬─────┘
                       │
                       ▼
                ┌──────────────┐
                │  Repository  │
                └──────┬───────┘
                       │
                       ▼
                ┌──────────────┐
                │    DbContext │
                └──────┬───────┘
                       │
                       ▼
                  SQL Server
```

### Authentication Flow

```text
Client
  │
  │ POST /api/auth/login
  ▼
AuthController
  │
  ▼
Auth Service
  │
  ├── Verify Password
  │
  └── JwtTokenService
          │
          ▼
       JWT Token
          │
          ▼
        Client
```

For protected requests:

```text
Client
  │
  │ Authorization: Bearer <JWT>
  ▼
ASP.NET Core Authentication
  │
  ▼
Token Validation
  │
  ▼
Authorization / Role Check
  │
  ▼
Controller
```

---

# 🧩 Architecture & Design Patterns

| Pattern / Practice      | Usage                                                                    |
| ----------------------- | ------------------------------------------------------------------------ |
| Repository Pattern      | Abstracts database operations behind repository contracts                |
| Service Layer           | Contains application/business logic                                      |
| Dependency Injection    | Provides loose coupling between components                               |
| Interface-Driven Design | Defines contracts between application components                         |
| DTO Pattern             | Separates API contracts from database entities                           |
| C# Records              | Used for concise request/response models                                 |
| Extension Methods       | Keeps service, repository, middleware, and logging configuration modular |
| Mapping Extensions      | Handles entity ↔ DTO transformations                                     |
| Standardized Responses  | Provides consistent API response structures                              |
| Middleware              | Handles HTTP pipeline cross-cutting concerns                             |
| Filters                 | Handles concerns such as validation and exception handling               |

---

# 🛠️ Tech Stack

| Technology            | Purpose                            |
| --------------------- | ---------------------------------- |
| ASP.NET Core          | Web API framework                  |
| C#                    | Primary programming language       |
| Entity Framework Core | ORM and database access            |
| SQL Server            | Relational database                |
| JWT                   | Authentication and authorization   |
| HMAC-SHA512 / HS512   | JWT signing algorithm              |
| Serilog               | Structured logging                 |
| Swagger / Swashbuckle | API documentation and testing      |
| Git                   | Version control                    |
| GitHub                | Source control and project hosting |

---

# 📂 Project Structure

```text
UserManagementWebAPI/
│
├── Controllers/
│   └── API endpoints
│
├── Data/
│   └── Application DbContext
│
├── DTOs/
│   ├── Auth/
│   └── Users/
│
├── Enums/
│   └── Application enumerations
│
├── Extensions/
│   ├── Mappers/
│   ├── MiddlewareExtension/
│   ├── RepositoryConfiguration/
│   └── ServiceConfiguration/
│
├── Filters/
│   ├── ValidationFilter.cs
│   └── ExceptionFilter.cs
│
├── Middlewares/
│   └── Custom middleware components
│
├── Migrations/
│   └── EF Core migrations
│
├── Repositories/
│   ├── Interfaces/
│   └── Implementations/
│
├── Response/
│   └── Standardized API response models
│
├── Services/
│   ├── Interfaces/
│   └── Implementations/
│
├── Utility/
│   └── Password hashing and security utilities
│
├── Program.cs
├── appsettings.json
└── README.md
```

---

# ⚙️ Getting Started

## 1. Clone the Repository

```bash
git clone https://github.com/devshahidkhan/UserManagementAPI.git

cd UserManagementAPI
```

---

## 2. Configure the Database

Configure your SQL Server connection string.

For development, a configuration may look like:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=UserDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

> **Security:** Never commit production database credentials or secrets to GitHub.

For production environments, use secure configuration mechanisms such as environment variables, secret managers, or cloud secret stores.

---

## 3. Configure JWT

Example development configuration:

```json
{
  "Jwt": {
    "Key": "YOUR_DEVELOPMENT_SECRET_KEY",
    "Issuer": "UserManagementWebAPI",
    "Audience": "UserManagementWebAPIUsers"
  }
}
```

For production, store the JWT signing key securely and **never commit the real secret to source control**.

---

## 4. Apply EF Core Migrations

```bash
dotnet ef database update
```

If EF Core CLI tools are not installed:

```bash
dotnet tool install --global dotnet-ef
```

---

## 5. Run the Application

```bash
dotnet run
```

ASP.NET Core will display the available application URLs in the terminal.

Swagger UI is available at:

```text
https://localhost:<port>/swagger
```

Use the HTTPS URL and port shown by your application.

---

# 📋 API Endpoints

## Authentication

| Method | Endpoint             | Description                        | Authentication |
| ------ | -------------------- | ---------------------------------- | -------------- |
| POST   | `/api/auth/register` | Register a new user                | Public         |
| POST   | `/api/auth/login`    | Authenticate user and generate JWT | Public         |

## Users

| Method | Endpoint          | Description             | Authentication |
| ------ | ----------------- | ----------------------- | -------------- |
| GET    | `/api/users`      | Retrieve all users      | Required       |
| GET    | `/api/users/{id}` | Retrieve user by ID     | Required       |
| PUT    | `/api/users/{id}` | Update an existing user | Required       |
| DELETE | `/api/users/{id}` | Delete a user           | Required       |

> Exact authorization requirements may vary depending on the roles configured for each endpoint.

---

# 🔑 Authentication Flow

### 1. Registration

The client sends registration information:

```http
POST /api/auth/register
```

The application:

```text
Password
   ↓
Generate Salt
   ↓
Hash Password + Salt
   ↓
Store Hash + Salt
   ↓
Database
```

The original plain-text password is never stored.

---

### 2. Login

The client sends credentials:

```http
POST /api/auth/login
```

The API:

```text
Username / Email + Password
            ↓
      Find User
            ↓
     Verify Password
            ↓
      Create Claims
            ↓
      Generate JWT
            ↓
        Return Token
```

---

### 3. Send JWT

The client sends the token with protected requests:

```http
Authorization: Bearer YOUR_JWT_TOKEN
```

---

### 4. Validate JWT

ASP.NET Core validates the token before allowing access to protected endpoints.

Validation includes:

```text
JWT
 │
 ├── Signature
 ├── Issuer
 ├── Audience
 └── Expiration
       │
       ▼
    Valid?
       │
   ┌───┴───┐
   │       │
  Yes      No
   │       │
   ▼       ▼
Allow    Reject
```

---

# 📦 Example API Response

Example successful user response:

```json
{
  "id": 1,
  "name": "John Doe",
  "email": "john@example.com"
}
```

The actual response structure depends on the DTO and standardized response model implemented by the application.

---

# 🔒 Security Practices

This project demonstrates several security practices:

* Password hashing and salting
* JWT-based stateless authentication
* Role-based authorization
* Token expiration
* Issuer and audience validation
* Signature validation
* Separation of API DTOs from entities
* Centralized exception handling
* Avoiding plain-text password storage
* Avoiding production secrets in source control

> **Important:** The example configuration values in this README are placeholders. Never commit real JWT signing keys, database passwords, API keys, or other secrets to GitHub.

---

# 🧪 Testing

The API can be tested using:

* Swagger UI
* Postman
* Any HTTP client

Recommended testing flow:

```text
1. Register User
      ↓
2. Login
      ↓
3. Copy JWT Token
      ↓
4. Authorize in Swagger
      ↓
5. Test Protected Endpoints
```

---

# 📈 Future Improvements

Possible future enhancements include:

* Refresh tokens
* Email verification
* Password reset functionality
* Pagination and filtering
* Advanced role and permission management
* Automated unit and integration tests
* API versioning
* Rate limiting
* Caching
* Health checks
* Docker support
* CI/CD pipeline
* Centralized production secret management

---

# 🤝 Contributing

Contributions, issues, and feature suggestions are welcome.

To contribute:

```text
Fork → Create Branch → Make Changes → Commit → Push → Pull Request
```

---

# 📜 License

This project is licensed under the **MIT License**.

---

# 👨‍💻 Author

**Shahid Raza Khan**

GitHub:
https://github.com/devshahidkhan
