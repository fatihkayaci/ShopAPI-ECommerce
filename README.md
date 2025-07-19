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
- **Repository Pattern** - Generic and Product-specific repositories
- **Entity Framework** - Database context with SQL Server
- **Database Integration** - Migrations and database creation
- **API Controllers** - Complete CRUD operations for Products
- **Dependency Injection** - Properly configured DI container
- **Swagger Documentation** - Interactive API documentation
- **Data Transfer Objects (DTOs)** - Request/Response models with validation
- **AutoMapper Integration** - Automatic object mapping
- **Service Layer** - Business logic separation with ProductService
- **Input Validation** - Comprehensive model validation with error handling
- **Business Rules** - Duplicate name checking, category defaults, stock validation

### 🚧 Next Steps
- **Exception Handling** - Global error handling middleware
- **Categories Entity** - Product-Category relationship implementation
- **Users & Authentication** - JWT implementation

### 📋 Future Features
- **Shopping Cart System** - Cart management
- **Order Processing** - Complete order workflow
- **Unit Testing** - Comprehensive test coverage
- **Performance Optimization** - Caching and optimization

---

## 🏗️ Architecture

This project follows **Clean Architecture** pattern with clear separation of concerns:

- **Domain Layer** - Business entities and core logic
- **Application Layer** - Use cases, interfaces, DTOs, business rules  
- **Infrastructure Layer** - Data access and external services
- **API Layer** - HTTP endpoints and controllers

## 🚀 Tech Stack

- **Framework:** ASP.NET Core 6+
- **Database:** Entity Framework Core with SQL Server
- **Object Mapping:** AutoMapper
- **Validation:** Data Annotations
- **Documentation:** Swagger/OpenAPI
- **Patterns:** Repository, Generic Repository, Service Layer, Dependency Injection

## 📁 Project Structure

```
📁 ShopAPI-ECommerce/
├── 📁 ShopAPI.Domain/          # Business entities
│   └── 📁 Entities/
│       └── Product.cs
├── 📁 ShopAPI.Application/     # Business logic & interfaces
│   ├── 📁 Interfaces/
│   │   ├── IGenericRepository.cs
│   │   ├── IProductRepository.cs
│   │   └── IProductService.cs
│   ├── 📁 DTOs/
│   │   ├── CreateProductDto.cs
│   │   ├── UpdateProductDto.cs
│   │   └── ProductResponseDto.cs
│   ├── 📁 Services/
│   │   └── ProductService.cs
│   └── 📁 Profiles/
│       └── ProductProfile.cs
├── 📁 ShopAPI.Infrastructure/  # Data access
│   ├── 📁 Data/
│   │   └── AppDbContext.cs
│   ├── 📁 Repositories/
│   │   ├── GenericRepository.cs
│   │   └── ProductRepository.cs
│   └── 📁 Migrations/
└── 📁 ShopAPI.API/            # HTTP layer
    ├── 📁 Controllers/
    │   └── ProductController.cs
    ├── Program.cs
    └── appsettings.json
```

## 🎯 API Endpoints

### Products
- `GET /api/product` - Get all products
- `GET /api/product/{id}` - Get product by ID
- `POST /api/product` - Create new product
- `PUT /api/product/{id}` - Update product
- `DELETE /api/product/{id}` - Delete product
- `GET /api/product/category/{category}` - Get products by category
- `GET /api/product/price-range?minPrice=100&maxPrice=1000` - Get products by price range
- `GET /api/product/search?searchTerm=iPhone` - Search products

### Planned Endpoints
- `POST /api/auth/register` - Register new user
- `POST /api/auth/login` - User login
- `GET /api/categories` - Get all categories
- `GET /api/cart` - Get cart items

## 🛠️ Getting Started

### Prerequisites
- .NET 6+ SDK
- SQL Server (LocalDB or Express) 
- Visual Studio 2022 or VS Code

### Setup Instructions

1. **Clone the repository**
   ```bash
   git clone https://github.com/fatihkayaci/ShopAPI-ECommerce.git
   cd ShopAPI-ECommerce
   ```

2. **Restore packages**
   ```bash
   dotnet restore
   ```

3. **Update connection string**
   Edit `ShopAPI.API/appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ShopAPIDb;Trusted_Connection=true;MultipleActiveResultSets=true"
     }
   }
   ```

4. **Create and update database**
   ```bash
   dotnet ef database update --project ShopAPI.Infrastructure --startup-project ShopAPI.API
   ```

5. **Build the solution**
   ```bash
   dotnet build
   ```

6. **Run the API**
   ```bash
   dotnet run --project ShopAPI.API
   ```

7. **Access Swagger UI**
   ```
   https://localhost:5001/swagger
   ```

## 📊 Current Development Status

| Component | Status | Description |
|-----------|--------|-------------|
| 🏗️ **Architecture** | ✅ Complete | Clean Architecture with 4 layers |
| 📁 **Project Structure** | ✅ Complete | Domain, Application, Infrastructure, API |
| 🎯 **Product Entity** | ✅ Complete | Core business entity implemented |
| 🔗 **Project References** | ✅ Complete | Proper dependency injection setup |
| 🗃️ **Repository Pattern** | ✅ Complete | Generic and Product repositories |
| 💾 **Database Context** | ✅ Complete | Entity Framework Core with SQL Server |
| 🌐 **API Endpoints** | ✅ Complete | RESTful Product CRUD operations |
| 📋 **Database Migration** | ✅ Complete | Initial database schema created |
| 🔧 **Dependency Injection** | ✅ Complete | Services properly registered |
| 📖 **Swagger Documentation** | ✅ Complete | Interactive API documentation |
| 📝 **DTOs** | ✅ Complete | Data Transfer Objects with validation |
| 🗺️ **AutoMapper** | ✅ Complete | Automatic object mapping |
| 🧠 **Service Layer** | ✅ Complete | Business logic separation |
| ✅ **Input Validation** | ✅ Complete | Model validation and error handling |
| 🛡️ **Exception Handling** | 🚧 Next | Global error handling middleware |
| 📂 **Categories** | 📋 Planned | Product-Category relationship |
| 🔐 **Authentication** | 📋 Planned | JWT implementation |

## 🧪 Testing the API

### Using Swagger UI
1. Run the application: `dotnet run --project ShopAPI.API`
2. Navigate to: `https://localhost:5001/swagger`
3. Test the endpoints directly in the browser

### Sample Product JSON
```json
{
  "productName": "iPhone 15",
  "description": "Latest Apple smartphone",
  "price": 999.99,
  "stock": 50,
  "category": "Electronics",
  "image": "iphone15.jpg"
}
```

### Sample API Calls
```bash
# Get all products
GET /api/product

# Search products
GET /api/product/search?searchTerm=iPhone

# Filter by price range
GET /api/product/price-range?minPrice=100&maxPrice=1000

# Get products by category
GET /api/product/category/Electronics
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

### Database Commands
```bash
# Add new migration
dotnet ef migrations add MigrationName --project ShopAPI.Infrastructure --startup-project ShopAPI.API

# Update database
dotnet ef database update --project ShopAPI.Infrastructure --startup-project ShopAPI.API

# Remove last migration
dotnet ef migrations remove --project ShopAPI.Infrastructure --startup-project ShopAPI.API
```

## 🌟 Design Patterns Used

- **Repository Pattern** - Data access abstraction
- **Generic Repository** - Code reusability across entities
- **Service Layer Pattern** - Business logic separation
- **DTO Pattern** - Data transfer and validation
- **Dependency Injection** - Loose coupling and testability
- **Clean Architecture** - Separation of concerns
- **Code First** - Database schema from C# entities

## 🎯 Next Development Steps

1. **Exception Handling** - Global error handling middleware
2. **Categories Management** - Product-Category relationships
3. **User Management** - User registration and authentication
4. **Shopping Cart** - Cart functionality
5. **Order Processing** - Order management system
6. **Unit Testing** - Repository and service tests
7. **Integration Testing** - API endpoint tests

## 🎯 Future Enhancements

- [ ] User Management System
- [ ] Shopping Cart Implementation
- [ ] Order Processing System
- [ ] Product Categories Management
- [ ] Image Upload Functionality
- [ ] Advanced Search and Filtering
- [ ] Pagination Support
- [ ] CQRS with MediatR
- [ ] Redis Caching
- [ ] Docker Support
- [ ] CI/CD Pipeline
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
- LinkedIn: [Fatih Kayacı](https://linkedin.com/in/fatihkayaci/)

## 🙏 Acknowledgments

- Clean Architecture principles by Robert C. Martin
- ASP.NET Core documentation
- Entity Framework Core best practices

---

⭐ **Star this repository if you find it helpful!**