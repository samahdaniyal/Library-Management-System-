# Library Management System: MVC & Entity Framework Core

A robust, enterprise-grade Library Management System built with **ASP.NET Core** and **C#**. This application demonstrates a clean separation of concerns using the **Model-View-Controller (MVC)** pattern, utilizing **Entity Framework Core (EF Core)** for seamless data persistence in a SQLite database.

---

## System Architecture

The project is structured into four distinct layers to ensure maintainability and testability:

### 1. Domain Layer (Core Business Logic)
At the heart of the system are the domain entities and services that enforce library rules.
* **Entities:** `Book`, `Member`, `Author`, and `Loan`.
* **Business Rules:** * Validation logic ensuring a single book cannot be loaned to multiple members simultaneously.
    * Constraint enforcement preventing members from borrowing more than three books at a time.
    * Many-to-Many relationship management between Books and Authors.
* **Services:** A dedicated `LoanService` handles the orchestration of borrowing and returning transactions.



### 2. Data Layer (Persistence)
Powered by **Entity Framework Core**, the data layer abstracts complex SQL operations into high-level C# code.
* **ORM Mapping:** Automatic mapping of domain objects to a **SQLite** database.
* **Migrations:** Utilization of EF Core Migrations to update database schemas (e.g., adding many-to-many join tables or indexes) without data loss.
* **Optimization:** Implementation of database indexes for high-performance query execution.



### 3. Controller Layer (Application Glue)
Controllers act as the intermediary, coordinating data flow between the user interface and the database.
* **Data Integration:** Fetching records from the `LibraryContext` and utilizing "Eager Loading" (via `.Include()`) for navigation properties.
* **Input Validation:** Ensuring data integrity before updating the domain models.

### 4. Presentation Layer (UI)
The user interface is built using **Razor Views**, combining standard HTML with dynamic C# templating.
* **Decoupling:** Views are strictly for display; no business logic is processed in the UI.
* **Features:** Dynamic forms for CRUD operations (Create, Read, Update, Delete) and interactive selection for many-to-many relationships (Books/Authors).



---

## Technical Features

* **Advanced Relationships:** Handles complex many-to-many associations between Books and Authors via join tables.
* **Schema Evolution:** Managed through code-first migrations (`InitialCreate`, `Authors`, `Indexes`).
* **Automated Testing:** Comprehensive test suite in `LibraryManagementSystem.Tests` ensuring logic reliability.
* **Containerized Development:** Full support for **VS Code Dev Containers** for instant environment setup.

---

## Getting Started

### Prerequisites
* **Dotnet SDK 9.0**
* **Entity Framework CLI Tools** (`dotnet-ef`)

### Setup & Installation

1. **Restore Dependencies:**
   ```bash
   dotnet restore
   ```
2. **Apply Migrations:** The application automatically handles database creation and migration application upon startup. To manually manage migrations:
   ```bash
   dotnet ef migrations add <MigrationName>
   ```
3. **Run the Application:**
   ```bash
   dotnet run --project LibraryManagementSystem
   ```
4. **Running Tests:**
   ```bash
   dotnet test
   ```
