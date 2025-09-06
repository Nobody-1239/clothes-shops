# Clothes Shop — ASP.NET Core MVC Project

This is a simple online clothing store built with ASP.NET Core MVC. Users can register and log in, browse products, add items to their cart, and administrators can manage products including uploading images.

---

## Features

- User registration and login with cookie-based authentication  
- Email existence check via Ajax before registration  
- Display of latest products on the homepage  
- Product detail view (accessible only to logged-in users)  
- Add products to cart with size selection  
- Personalized shopping cart for each user  
- Admin panel for adding new products with image upload  
- Filter products by category  

---

## Technologies Used

| Technology | Purpose |
|------------|---------|
| ASP.NET Core MVC | Web application framework |
| Entity Framework Core | ORM for database access |
| SQL Server | Database |
| Cookie Authentication | User authentication |
| HTML/CSS/Bootstrap | UI design (optional) |

---

## Project Structure
```
Clothes/
├── Controllers/
│   ├── AccountController.cs
│   ├── AdminController.cs
│   ├── HomeController.cs
│   ├── OrderController.cs
│   └── ProductController.cs
├── Middleware/
│   └── IsAdmin.cs
├── Models/
│   └── User.cs, Product.cs, Category.cs, Order.cs, OrderItem.cs
├── Data/
│   └── ShopContext.cs
├── Views/
│   ├── Account/
│   ├── Admin/
│   ├── Home/
│   ├── Order/
│   ├── Product/
│   └── Shared/
├── wwwroot/
│   └── images/
```
## 📽️ Demo

Watch the demo video here:  
(https://uupload.ir/view/1_93ej.mp4/)

