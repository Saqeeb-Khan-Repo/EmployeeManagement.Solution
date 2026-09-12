# Employee Management Web API

A job-oriented ASP.NET Core Web API project built with C#, Entity Framework Core, SQL Server, DTOs, Dependency Injection, service-layer architecture, reusable validation, and `ServiceResult<T>`.

The purpose of this project is to learn how a real .NET backend is structured and to build strong practical skills for software engineering jobs.

---

# Project Goals

This project is designed to practice:

- C# and Object-Oriented Programming
- ASP.NET Core Web API
- REST API design
- Entity Framework Core
- SQL Server
- LINQ
- Async/Await
- Dependency Injection
- DTOs
- Entity-to-DTO mapping
- Service Layer
- Validation Helpers
- Business Validation
- ServiceResult pattern
- HTTP status codes
- Clean separation of responsibilities

---

# Technology Stack

- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- LINQ
- Swagger / OpenAPI
- Entity Framework Core Migrations
- Dependency Injection
- Postman

---

# Solution Structure

```text
EmployeeManagement.Solution
│
├── EmployeeManagement.WebAPI
│   ├── Controllers
│   │   └── HomeController.cs
│   ├── Middleware
│   └── Program.cs
│
├── Entities.WebAPI
│   └── Employee.cs
│
├── ServiceContracts.WebAPI
│   ├── EmployeeAddRequest.cs
│   ├── EmployeeResponse.cs
│   └── IEmployeeService.cs
│
└── Services.WebAPI
    ├── EmployeeService.cs
    ├── EmployeeValidationHelper.cs
    ├── EmployeeExtensions.cs
    └── ServiceResult.cs
