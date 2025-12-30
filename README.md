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
* **Available:** $Available = OnHand - Reserved$.



### 2. StockMovement (Entity)
An immutable audit record tracking every single change (additions, subtractions, reservations) for full traceability and reconciliation.

### 3. Warehouse & StorageLocation
Entities and Value Objects representing physical locations, zones, and bins within the supply chain.

---

## 🗂 Repository Structure & Clean Architecture

The project follows a strict Clean Architecture pattern:

```text
EPart.sln
├── src
│   └── Warehouse
│       └── Warehouse.Api
│           ├── Domain          # Aggregate Roots, Entities, Value Objects, Domain Exceptions
│           ├── Application     # CQRS (Commands/Queries), MediatR Handlers, AutoMapper, Validators
│           ├── Infrastructure  # DBContext (EF Core), Repository Implementations, Persistence Config
│           └── API             # Controllers, Middlewares, Dependency Injection Setup
├── compose.yaml                # Infrastructure orchestration (SQL Server, RabbitMQ)
└── README.md
‍‍‍```

## 🔄 Technical Implementation Details

* **MediatR:** Used for decoupled communication between the API and Application layers, handling the dispatching of Commands and Queries (CQRS).
* **FluentValidation:** Ensures all incoming data is validated before reaching the business logic handlers, providing a clean way to manage validation rules.
* **AutoMapper:** Simplifies the mapping between Domain Entities and Data Transfer Objects (DTOs), reducing boilerplate code in the API layer.
* **Entity Framework Core:** Powering the Persistence layer with SQL Server, utilizing Fluent API for data modeling and managing migrations.

---

## 🛠 Technology Stack

| Component | Technology |
| :--- | :--- |
| **Language / Framework** | C# / .NET 7+ |
| **Pattern Handling** | MediatR (Mediator Pattern) |
| **Validation** | FluentValidation |
| **Persistence** | Entity Framework Core |
| **Object Mapping** | AutoMapper |
| **Containerization** | Docker & Docker Compose |

---

## 🚀 Getting Started

### Prerequisites
Before running the project, ensure you have the following installed:
* .NET 7 SDK or later
* Docker & Docker Compose
* SQL Server (if running locally without Docker)

### Run with Docker Compose
To spin up the necessary infrastructure (Database, Brokers, etc.), execute the following command in your terminal:

```bash
docker compose up --build
