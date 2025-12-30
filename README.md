# 🏭 EPart – Spare Parts Supply Chain (Warehouse Microservice)

EPart is a microservice-based system designed to manage the **spare parts supply chain**, starting from inventory storage and warehouse operations up to integration with order fulfillment and delivery systems.

This repository currently focuses on the **Warehouse Microservice**, which serves as the physical source of truth for inventory in a distributed, event-driven architecture.

---

## 📌 Project Vision
The goal of EPart is to model a **real-world spare parts supply chain** using:
* **Microservices Architecture:** Decoupled, scalable services.
* **Domain-Driven Design (DDD):** Focus on the core domain logic (Aggregates, Value Objects).
* **Event-Driven Communication:** Asynchronous integration via Message Brokers.
* **Clean Architecture:** Strict separation of Domain, Application, Infrastructure, and API layers.

---

## 🧱 Architecture Overview



* **Independent microservices** per bounded context.
* **CQRS Pattern:** Separation of Read (Queries) and Write (Commands) using **MediatR**.
* **Asynchronous communication:** Designed for integration via domain events (RabbitMQ/Kafka).
* **Strong consistency** inside the Warehouse service; **Eventual consistency** across the system via Sagas.

---

## 🧩 Bounded Context: Warehouse
The Warehouse context is responsible for the physical reality of the inventory.

| ✅ Responsibility | ❌ Out of Scope |
| :--- | :--- |
| Tracking physical inventory levels | Order Placement & Pricing |
| Managing stock availability (SKUs) | Customer Profile Management |
| Reserving stock for pending orders | Payment Processing |
| Shipping and releasing stock | Delivery Routing & Logistics |
| Recording movement audit logs | Procurement/Supplier Negotiation |

---

## 📦 Core Domain Model (`Warehouse.Domain`)

### 1. InventoryItem (Aggregate Root)
The primary aggregate that enforces inventory business rules:
* **On-Hand:** Total physical items currently in the building.
* **Reserved:** Items allocated to an order but not yet shipped.
* **Available:** $OnHand - Reserved$.



### 2. StockMovement (Entity)
An immutable audit record tracking every single change (additions, subtractions, reservations) for full traceability and reconciliation.

### 3. Warehouse & StorageLocation
Entities and Value Objects representing physical locations, zones, and bins within the supply chain.

---

## 🗂 Repository Structure & Clean Architecture

The project follows a strict Clean Architecture pattern as implemented in the source:

```text
EPart.sln
├── src
│   └── Warehouse
│       └── Warehouse.Api
│           ├── Domain          # Aggregate Roots, Entities, Value Objects, Domain Exceptions
│           ├── Application     # CQRS (Commands/Queries), MediatR Handlers, AutoMapper, Validators
│           ├── Infrastructure  # DBContext (EF Core), Repository Implementations, Persistence Config
│           └── API             # Controllers, Middlewares, Dependency Injection Setup
├── compose.yaml                # Infrastructure orchestration (SQL Server, RabbitMQ)
└── README.md
🔄 Technical Implementation DetailsMediatR: Used for decoupled communication between the API and Application layers, handling the dispatching of Commands and Queries.FluentValidation: Ensures all incoming data is validated before reaching the business logic handlers.AutoMapper: Simplifies the mapping between Domain Entities and Data Transfer Objects (DTOs) for the API layer.Entity Framework Core: Powering the Persistence layer with SQL Server, using Fluent API for data modeling and migrations.


🚀 Getting StartedPrerequisites.NET 7 or laterDocker & Docker ComposeSQL ServerRun with Docker ComposeTo spin up the necessary infrastructure:Bashdocker compose up --build
API Endpoints (Swagger Enabled)MethodEndpointDescriptionPOST/api/inventory/receiveAdd new stock to a warehousePOST/api/inventory/reserveReserve items for a specific orderPOST/api/inventory/shipFinalize shipment and deduct stockGET/api/inventory/{sku}Check current stock levels for a part🛠 Technology StackC# / .NETMediatR (Mediator Pattern)FluentValidation (Validation)Entity Framework Core (Persistence)AutoMapper (Object Mapping)Docker & Compose (Containerization)

🧪 Future RoadmapOrder Service: Integration via Saga Pattern (Choreography/Orchestration).Multi-Warehouse: Support for stock transfers and intelligent routing between locations.Observability: Adding OpenTelemetry for distributed tracing across microservices.

📄 LicenseThis project is intended for architectural, educational, and experimental purposes.
***

**Would you like me to help you create a GitHub Actions workflow file (`.github/workflows/main.




