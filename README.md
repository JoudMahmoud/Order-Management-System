# Order Management System API

A robust **ASP.NET Core Web API** for managing customers, products, orders, invoices, and users. The system provides secure authentication using **JWT**, **Role-Based Access Control (RBAC)**, inventory management, automated invoice generation, and business rules such as tiered discounts and stock validation.

This project follows a clean layered architecture with repositories, services, and controllers to ensure maintainability, scalability, and testability.

---

## Features

### Customer Management

* Register new customers
* Retrieve customer order history

### Order Management

* Create new orders
* View order details
* Retrieve all orders (Admin)
* Update order status (Admin)
* Automatic invoice generation
* Inventory validation
* Automatic stock updates

### Product Management

* View available products
* Retrieve product details
* Add new products (Admin)
* Update existing products (Admin)

### Invoice Management

* Retrieve invoice details
* View all invoices (Admin)

### User Authentication & Authorization

* User registration
* Secure login with JWT Authentication
* Role-Based Access Control (Admin & Customer)
* Protected API endpoints

---

## Business Rules

The application includes several real-world business rules:

* Validate product stock before creating an order.
* Prevent ordering unavailable products.
* Automatically reduce inventory after successful orders.
* Apply tiered discounts:

  * **5%** discount for orders over **$100**
  * **10%** discount for orders over **$200**
* Support multiple payment methods:

  * Credit Card
  * PayPal
* Generate invoices automatically after successful order creation.
* Send email notifications when order status changes.

---

## Technologies Used

* ASP.NET Core Web API
* C#
* Entity Framework Core
* In-Memory Database
* LINQ
* JWT Authentication
* Role-Based Authorization (RBAC)
* Swagger / OpenAPI
* xUnit (Unit Testing)

---

## Project Structure

```
OrderManagementSystem
│
├── Controllers
├── Services
├── Repositories
├── Models
├── DTOs
├── Data
├── Authentication
├── Middleware
├── Helpers
└── Tests
```

---

## API Endpoints

### Customers

| Method | Endpoint                             | Description            |
| ------ | ------------------------------------ | ---------------------- |
| POST   | `/api/customers`                     | Create customer        |
| GET    | `/api/customers/{customerId}/orders` | Customer order history |

### Orders

| Method | Endpoint                  | Access        |
| ------ | ------------------------- | ------------- |
| POST   | `/api/orders`             | Customer      |
| GET    | `/api/orders/{id}`        | Authenticated |
| GET    | `/api/orders`             | Admin         |
| PUT    | `/api/orders/{id}/status` | Admin         |

### Products

| Method | Endpoint             | Access |
| ------ | -------------------- | ------ |
| GET    | `/api/products`      | Public |
| GET    | `/api/products/{id}` | Public |
| POST   | `/api/products`      | Admin  |
| PUT    | `/api/products/{id}` | Admin  |

### Invoices

| Method | Endpoint             | Access |
| ------ | -------------------- | ------ |
| GET    | `/api/invoices`      | Admin  |
| GET    | `/api/invoices/{id}` | Admin  |

### Users

| Method | Endpoint              | Description        |
| ------ | --------------------- | ------------------ |
| POST   | `/api/users/register` | Register user      |
| POST   | `/api/users/login`    | Generate JWT Token |

---

## Security

The API is secured using:

* JWT Bearer Authentication
* Password hashing
* Role-Based Authorization
* Protected administrative endpoints

---

## Validation & Error Handling

The application includes:

* Model validation
* Stock availability checks
* Invalid order prevention
* Global exception handling
* Meaningful API responses

---

## Testing

Critical business logic is covered using unit tests, including:

* Discount calculation
* Stock validation
* Order creation
* Invoice generation

---

## API Documentation

Swagger UI is integrated for interactive API testing and documentation.

Run the project and navigate to:

```
https://localhost:{port}/swagger
```

---

## Future Improvements

* SQL Server integration
* Refresh Tokens
* Redis caching
* Docker support
* Payment gateway integration (Stripe/PayPal)
* Order tracking
* Pagination & filtering
* Logging with Serilog
* Background email service
* CI/CD pipeline
* Cloud deployment (Azure)

---

## Learning Outcomes

This project demonstrates practical experience with:

* RESTful API development
* Clean Architecture principles
* Repository & Service patterns
* Entity Framework Core
* Authentication & Authorization
* Business rule implementation
* Inventory management
* API documentation
* Unit testing
* Secure application development
