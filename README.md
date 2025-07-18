# 🛒 ShopAPI - E-commerce Management System

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![.NET](https://img.shields.io/badge/.NET-6+-purple.svg)](https://dotnet.microsoft.com/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-6+-blue.svg)](https://docs.microsoft.com/en-us/aspnet/core/)

Modern e-commerce backend API built with Clean Architecture principles and ASP.NET Core.

## 💡 What's Implemented So Far

### ✅ Completed Features
- **Clean Architecture Setup** - 4-layer architecture implemented
- **Project Structure** - Domain, Application, Infrastructure, API layers
- **Product Entity** - Core business entity with proper data types
- **Project References** - Proper dependency flow between layers
- **Git Repository** - Version control with .gitignore and documentation

### 🚧 In Progress
- **Repository Pattern** - Interface and implementation (next step)
- **Entity Framework** - Database context setup
- **API Controllers** - RESTful endpoints
- **Database Integration** - SQL Server with EF Core

### 📋 Planned Features
- **Authentication & Authorization** - JWT implementation
- **Shopping Cart System** - Cart management
- **Order Processing** - Complete order workflow
- **Unit Testing** - Comprehensive test coverage

---

## 🏗️ Architecture

This project follows **Clean Architecture** pattern with clear separation of concerns:

- **Domain Layer** - Business entities and core logic
- **Application Layer** - Use cases and business rules  
- **Infrastructure Layer** - Data access and external services
- **API Layer** - HTTP endpoints and controllers

## 🚀 Tech Stack

- **Framework:** ASP.NET Core 6+
- **Database:** Entity Framework Core with SQL Server
- **Authentication:** JWT Bearer Token
- **Documentation:** Swagger/OpenAPI
- **Testing:** xUnit
- **Patterns:** Repository, Unit of Work, CQRS

## 📁 Project Structure

```
📁 ShopAPI-ECommerce/
├── 📁 ShopAPI.Domain/          # Business entities
│   └── 📁 Entities/
├── 📁 ShopAPI.Application/     # Business logic
│   ├── 📁 Interfaces/
│   └── 📁 Services/
├── 📁 ShopAPI.Infrastructure/  # Data access
│   ├── 📁 Data/
│   └── 📁 Repositories/
└── 📁 ShopAPI.API/            # HTTP layer
    └── 📁 Controllers/
```

## 🎯 Features

### Core Features
- ✅ Product Management (CRUD)
- ✅ Category Management
- ✅ User Authentication & Authorization
- ✅ Shopping Cart Operations
- ✅ Order Processing
- ✅ Stock Management

### Technical Features
- ✅ Clean Architecture Implementation
- ✅ Repository Pattern
- ✅ Generic Repository
- ✅ Unit of Work Pattern
- ✅ JWT Authentication
- ✅ Input Validation
- ✅ Error Handling
- ✅ API Documentation (Swagger)

## 🛠️ Getting Started

### Prerequisites
- .NET 6+ SDK
- SQL Server (LocalDB or Express) 
- Visual Studio 2022 or VS Code

### Current Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/fatihkayaci/ShopAPI-ECommerce.git
   cd ShopAPI-ECommerce
   ```

2. **Restore packages**
   ```bash
   dotnet restore
   ```

3. **Build the solution**
   ```bash
   dotnet build
   ```

4. **Run the API project** (Basic setup - no database yet)
   ```bash
   dotnet run --project ShopAPI.API
   ```

5. **Access Swagger UI** (when implemented)
   ```
   https://localhost:5001/swagger
   ```

### Next Steps in Development
- Implement Repository Pattern
- Add Entity Framework DbContext  
- Create API Controllers
- Add database migrations

## 📊 Current Development Status

| Component | Status | Description |
|-----------|--------|-------------|
| 🏗️ **Architecture** | ✅ Complete | Clean Architecture with 4 layers |
| 📁 **Project Structure** | ✅ Complete | Domain, Application, Infrastructure, API |
| 🎯 **Product Entity** | ✅ Complete | Core business entity implemented |
| 🔗 **Project References** | ✅ Complete | Proper dependency injection setup |
| 📝 **Documentation** | ✅ Complete | README and LICENSE files |
| 🗃️ **Repository Pattern** | 🚧 Next | Interface and implementation |
| 💾 **Database Context** | 📋 Planned | Entity Framework Core setup |
| 🌐 **API Endpoints** | 📋 Planned | RESTful controllers |
| 🔐 **Authentication** | 📋 Planned | JWT implementation |

---

### Products
- `GET /api/products` - Get all products
- `GET /api/products/{id}` - Get product by ID
- `POST /api/products` - Create new product
- `PUT /api/products/{id}` - Update product
- `DELETE /api/products/{id}` - Delete product

### Authentication
- `POST /api/auth/register` - Register new user
- `POST /api/auth/login` - User login
- `POST /api/auth/refresh` - Refresh token

### Shopping Cart
- `GET /api/cart` - Get cart items
- `POST /api/cart/add` - Add item to cart
- `PUT /api/cart/update` - Update cart item
- `DELETE /api/cart/remove` - Remove from cart

## 🧪 Testing

```bash
# Run unit tests
dotnet test

# Run with coverage
dotnet test --collect:"XPlat Code Coverage"
```

## 🔧 Development

### Building
```bash
dotnet build
```

### Running
```bash
dotnet run --project ShopAPI.API
```

### Package Installation
```bash
# Entity Framework
dotnet add ShopAPI.Infrastructure package Microsoft.EntityFrameworkCore.SqlServer

# AutoMapper
dotnet add ShopAPI.Application package AutoMapper.Extensions.Microsoft.DependencyInjection
```

## 🌟 Design Patterns Used

- **Repository Pattern** - Data access abstraction
- **Unit of Work** - Transaction management
- **Generic Repository** - Code reusability
- **Dependency Injection** - Loose coupling
- **CQRS** - Command Query separation (planned)

## 🎯 Future Enhancements

- [ ] CQRS with MediatR
- [ ] Event Sourcing
- [ ] Redis Caching
- [ ] Background Jobs (Hangfire)
- [ ] API Rate Limiting
- [ ] Docker Support
- [ ] CI/CD Pipeline
- [ ] Integration Tests
- [ ] Performance Monitoring

## 📝 Contributing

1. Fork the project
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👨‍💻 Author

**Fatih Kayacı**
- GitHub: [@fatihkayaci](https://github.com/fatihkayaci)
- LinkedIn: [Fatih Kayacı](https://linkedin.com/in/fatihkayaci)

## 🙏 Acknowledgments

- Clean Architecture principles by Robert C. Martin
- ASP.NET Core documentation
- Entity Framework Core best practices

---

⭐ **Star this repository if you find it helpful!**