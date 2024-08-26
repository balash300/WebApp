### README

# Web App Backend - Category and Product Management

This is the backend API for a category and product management system, built with ASP.NET Core. It provides RESTful endpoints for managing categories and products, including create, read, update, and delete (CRUD) operations.

## Features
- **Category Management**: Create, retrieve, update, and delete categories.
- **Product Management**: Create, retrieve, update, and delete products.
- **Swagger Documentation**: Automatically generated API documentation and testing interface.

## Prerequisites
- .NET 6.0 SDK or higher
- Microsoft SQL Server

## Setup Instructions

1. Clone the repository:
    ```bash
    git clone https://github.com/your-username/web-app-backend.git
    cd web-app-backend
    ```

2. Restore dependencies:
    ```bash
    dotnet restore
    ```

3. Configure the database connection in `appsettings.json`:
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DATABASE;Trusted_Connection=True;MultipleActiveResultSets=true"
    }
    ```

4. Apply database migrations:
    ```bash
    dotnet ef database update
    ```

5. Run the application:
    ```bash
    dotnet run
    ```

6. Access the API documentation:
    - Navigate to `https://localhost:5001/swagger` in your browser for the Swagger UI.

## Project Structure

- **Program.cs**: Sets up the web application and configures services such as controllers, database context, and repositories.
- **DataContext**: Manages database connections and entity configurations using Entity Framework Core.
- **Repositories**: Contains the interfaces and implementations for category and product data access.

## Technologies Used
- ASP.NET Core 6.0
- Entity Framework Core
- SQL Server
- Swagger for API documentation
- CORS configuration for flexible frontend-backend communication

## Usage

- The backend provides API endpoints for categories and products. You can interact with these endpoints via HTTP clients like Postman or directly via the Swagger UI.
  
- Example Endpoints:
  - `GET /api/categories`
  - `POST /api/categories`
  - `PUT /api/categories/{id}`
  - `DELETE /api/categories/{id}`

This backend serves as the core service for managing categories and products in the system, enabling frontend applications to perform operations efficiently.
