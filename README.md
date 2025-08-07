# 🧩 Dynamic Form Builder with ASP.NET Core, Blazor, and MongoDB

This POC demonstrates how to dynamically define and render forms using:
- MongoDB (for dynamic field definitions and asset data)
- ASP.NET Core Web API (for backend services)
- Blazor WebAssembly (for frontend form builder and renderer)

---

## 🚀 Getting Started

### 1. Provision MongoDB (via Docker)

```bash
docker-compose up -d
```

> Make sure Docker is running.

---

### 2. Run the ASP.NET Core API (Server)

```bash
cd DynamicFormAPI
dotnet run
```

API Swagger available at:  
👉 http://localhost:5297/swagger

---

### 3. Run the Blazor WebAssembly Client

```bash
cd DynamicFormClient/Client
dotnet run
```

Blazor client available at:

- 🔧 Field Builder: http://localhost:5239/fieldbuilder  
  Define custom fields for your form

- 📄 Form Renderer: http://localhost:5239/create  
  View and submit forms based on your defined fields

---

## 🔐 CORS Setup

If you're running the Blazor app on a different port or domain, update CORS settings in `DynamicFormAPI/Program.cs`:

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient", policy =>
    {
        policy.WithOrigins("http://localhost:5239") // Replace with your Blazor client URL
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

app.UseCors("AllowBlazorClient");
```

---

## 🧠 Notes

- Field definitions are stored in MongoDB (`field_definitions` collection)
- Assets submitted from the form are stored in a separate collection (to be implemented)

---

## 📦 Coming Soon

- Per-tenant dynamic field management
- Dynamic validation based on field definitions
- Asset data submission and listing

---

## 🛠️ Tech Stack

- .NET 8 / ASP.NET Core
- Blazor WebAssembly
- MongoDB
- Docker (for containerized MongoDB)

---

## 🧑‍💻 Author

Dylan Lee 
dylanlee.sg
