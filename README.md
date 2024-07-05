
# TicketSystemTask

Ticket management system developed using .NET Core with Domain-Driven Design (DDD), CQRS pattern, and Mediator Pattern with MediatR in the backend,
and Angular in the frontend. The system allows you to create, list, and handle tickets.
Automated Handling
Tickets are automatically marked as "handled" if they were created within 60 minutes.
Ticket Coloring
Tickets are colored according to their creation time:
Yellow: Created 15 minutes ago.
Green: Created 30 minutes ago.
Blue: Created 45 minutes ago.
Red: Created 60 minutes ago.

# Backend
## Technologies Used
- .NET Core
- Entity Framework Core
- DDD (Domain Driven Design)
- SQL Server
- MediatR
- Repository Pattern
- CQRS

## Getting Started
- Clone the repository to your local machine.

- Open the appsettings.json file and configure the database connection string according to your SQL Server setup.

- Open the solution in Visual Studio or your preferred IDE.

- Build and run the backend application.
- 
## Domain Entities
- Ticket: Represents a support ticket with properties like Id, creation date, phone number, governorate, city, district, and status.
## Backend Structure
- Controllers: The API endpoints for ticket management.
- Domain: Contains domain entities (Ticket).
- Application: Contains the application services, commands, and queries to Tickets.
- Infrastructure: Contains database-related code, EF Core configurations, and repositories.
- Mediators: Implement MediatR handlers for commands and queries.
- DTOs: Data Transfer Objects for API responses.
- TicketSystemTask as a Presentaion Layer to API Controlle

# Frontend (Angular)
## Technologies Used
Angular
## Getting Started
Navigate to the frontend directory within the project.

Open a terminal and run npm install to install the necessary dependencies.

Run ng serve to start the Angular application.

Access the Angular app in your browser at http://localhost:4200.

## Frontend Structure
Components: Contains Angular components for creating and listing tickets(home-page , create-new-ticket).
Services: Provides communication with the backend API(ticket.service).
