# AcademiasAPI

**AcademiasAPI** is an ASP.NET Web API designed for gym management. It
allows gyms to register machines and exercises, instructors to create
training plans, and students to track their workout progress.\
This project is intended solely for learning and architectural
exploration and is **not meant for production use**.

> ⚠️ **Important Notice:**\
> The source code is written in **Portuguese (Brazil)** for educational
> purposes.

------------------------------------------------------------------------

## 📐 Architecture

The solution follows a **layered architecture**, divided into three main
projects:

-   **Presentation** -- Exposes HTTP endpoints (Web API layer).\
-   **Domain** -- Contains business rules, entities, and interfaces.\
-   **Infrastructure** -- Implements data access, repositories, and
    database scripts.

Additional relevant structure:

    Infrastructure/Database/Bootstrap.sql

This file contains all SQL needed to create the PostgreSQL database
schema.

------------------------------------------------------------------------

## 🛠️ Technologies Used

-   .NET / ASP.NET\
-   PostgreSQL\
-   Swagger (OpenAPI)

------------------------------------------------------------------------

## 🗄️ Database

The API uses **PostgreSQL**.

Entity Framework migrations are **not** used.\
The schema must be created manually using:

    Infrastructure/Database/Bootstrap.sql

Ensure the script is executed before running the application.

------------------------------------------------------------------------

## ⚙️ Configuration

All configuration values---including connection strings---are stored in:

    appsettings.Development.json

No additional environment variables are required.

------------------------------------------------------------------------

## ▶️ Running the Project Locally

1.  Start your PostgreSQL instance.
2.  Execute the `Bootstrap.sql` script.
3.  Run the API with:

``` bash
dotnet run
```

The API will be available at:

    https://localhost:5001

(Or according to your local configuration.)

------------------------------------------------------------------------

## 📚 API Documentation

Swagger UI is enabled in development.

Access it at:

    https://localhost:5001/swagger

------------------------------------------------------------------------

## 📂 Folder Structure (Summary)

    AcademiasAPI/
    ├── Presentation/
    │   └── Controllers/
    │   └── Constants/
    │   └── Middlewares/
    ├── Domain/
    |   ├── Attributes/
    |   ├── Dto/
    │   ├── Exceptions/
    │   ├── Models/
    │   └── Services/
    └── Infrastructure/
        ├── Database/
        ├── Repositories/
        ├── CrossCutting/
        └── Storage/

------------------------------------------------------------------------

## 📄 License

This project is licensed under the **MIT License**.

------------------------------------------------------------------------

## 📌 Project Status

🚧 **Under development**\
This project is intended for learning and architectural practice and
**not for production deployment**.
