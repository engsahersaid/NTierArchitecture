# N-Tier Architecture

N-tier architecture is a software architecture pattern that separates an application into multiple layers or tiers. Each tier has a specific responsibility and communicates with the next tier to achieve the desired functionality.

Layers or Tiers are just a physical and logical separation of concerns, it is often referred to as n-tiered application where n is the number of separations.


## Layers

The Most common layers number 3 layers:

1. Presentation Layer
2. Business Logic Layer
3. Data Access Layer
4. Model Layer Optional

![image](https://github.com/user-attachments/assets/ddc0c6c3-89cc-4fdf-ba61-f0b6d3982ab3)


the presentation layer depends on a business logic layer, which in turn depends on the data access layer and so on.

### Presentation Layer

The presentation layer is responsible for handling user input and displaying data to the user. This layer is typically implemented using a web framework or a GUI library.

- This uses MVC (Model-View-Controller) pattern and holds Presentation layer logic. For Models, it uses Model layer objects.

### Business Logic Layer

The business logic layer is responsible for implementing the application's logic and rules. This layer is typically implemented using a programming language such as Java or C#.

- It holds the Application logic. Application layer call methods of Repository layer for CRUD operations. The repository layer returns the data in Domain layer Entities. The application layer performs an additional logic and returns the data in Model objects to the Web layer.
- The model is shared between the application and web layers. The application layer returns the data in Model objects to the Web layer.

### Data Access Layer

The data access layer is responsible for interacting with the database or data storage system. This layer is typically implemented using an ORM (Object-Relational Mapping) tool or a database library.

The database is usually the Core of the Entire Application.
It is the only layer that doesn’t have to depend on anything else. Any small change in the Business Logics layer or Data access layer may prove dangerous to the integrity of the entire application.

- **Domain** It holds Entity Framework Context and Entities created using Code First from the database approach.
- **Repository** It holds code for CRUD operations, using Generic Repository and Unit-of-Work patterns.

### Model Layer 

Contains DB Entities and shared model in the application 

## Used Technologies

- C#
- Asp.net Core 8
- Swagger
- Entity Framework Core 8 Code Frist
- AutoMapper
- Fluent API
- Fluent Validation
- Repository Pattern
- Unit of work

