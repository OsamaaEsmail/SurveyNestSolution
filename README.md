# SurveyNestSolution
 A professional survey management system built with **.NET 9** using **Clean Architecture**  principles.


## 📋 Table of Contents

- [Overview](#overview)
- [Architecture](#architecture)
- [Features](#features)
- [Tech Stack](#tech-stack)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
- [API Endpoints](#api-endpoints)
- [Configuration](#configuration)

---
## 🌟 Overview

SurveyNest is a full-featured survey management REST API that allows organizations to create, manage, and analyze surveys. It supports role-based access control, JWT authentication, background jobs, caching, and more.


The project follows **Clean Architecture** with **Onion Architecture** principles:

```
┌─────────────────────────────────────┐
│           SurveyNest.API            │  ← Presentation Layer
├─────────────────────────────────────┤
│       SurveyNest.Application        │  ← Business Logic Layer
├─────────────────────────────────────┤
│       SurveyNest.Infrastructure     │  ← Data Access Layer
├─────────────────────────────────────┤
│         SurveyNest.Domain           │  ← Core Domain Layer
├─────────────────────────────────────┤
│      SurveyNest.BuildingBlocks      │  ← Shared Utilities
└─────────────────────────────────────┘
```



## ✨ Features

### 🔐 Authentication & Authorization
- JWT Bearer Token Authentication
- Refresh Token with revocation support
- Role-based Authorization (Admin / Member)
- Permission-based Authorization (granular control)
- Email Confirmation
- Password Reset via email

### 📊 Survey Management
- Full CRUD for Polls with soft delete
- Question management with multiple answers
- Poll publishing with date scheduling
- API Versioning (v1 / v2)

### 🗳️ Voting System
- One vote per user per poll
- Real-time vote validation
- Duplicate vote prevention
- Vote results analytics

### 📈 Results & Analytics
- Votes per day statistics
- Votes per question breakdown
- Full poll votes report

### 👥 User Management
- User registration and profile management
- Role assignment
- Account enable/disable (Soft Delete)
- Account unlock after lockout

### ⚙️ Infrastructure
- **HybridCache** for performance optimization
- **Hangfire** for background jobs (email notifications)
- **Serilog** structured logging with file sink
- **Health Checks** for API and Database monitoring
- **Rate Limiting** per IP and per User
- **CORS** with configurable allowed origins
- **Swagger UI** with JWT support and API versioning

---

## 🛠️ Tech Stack

| Category | Technology |
|---|---|
| Framework | .NET 9 / ASP.NET Core |
| ORM | Entity Framework Core 9 |
| Database | SQL Server |
| Authentication | JWT Bearer + ASP.NET Identity |
| Caching | HybridCache |
| Background Jobs | Hangfire |
| Logging | Serilog |
| Mapping | Mapster |
| Validation | FluentValidation |
| Email | MailKit |
| API Docs | Swagger / Swashbuckle |
| Health Checks | AspNetCore.HealthChecks |

---

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE.txt) file for details.

---

## 👨‍💻 Author

**Osama Esmail** - [@OsamaaEsmail](https://github.com/OsamaaEsmail)

---

<div align="center">
  <p>Built with  using .NET 9 and Clean Architecture</p>
</div>
