# Project Blueprint

## 1. Overview

This project is a modern, full-stack e-commerce web application for a "Biryani Shop." It is built with .NET and is designed to provide a seamless and visually appealing user experience. The application allows users to browse a menu of biryanis, add them to a shopping cart, and create an account to manage their orders.

## 2. Architecture & Tech Stack

*   **Backend**: C# with ASP.NET Core MVC
*   **Identity**: ASP.NET Core Identity for user authentication and authorization
*   **Database**: SQLite managed with Entity Framework Core (Code-First approach)
*   **Frontend**: Razor Views for server-side rendering
*   **Styling**: Custom CSS for a modern, clean look.

## 3. Style, Design, and Features

### 3.1. Aesthetics & Design

*   **Modern & Clean UI**: The application features a visually balanced layout with clean spacing and polished styles, creating a unique and intuitive user experience.
*   **Responsive Design**: The app is fully mobile-responsive, adapting to different screen sizes to work perfectly on both mobile devices and desktops.
*   **Engaging Visuals**: The site uses a hero section with a compelling headline and a call-to-action to draw users in. The menu is presented in a clear and organized manner.
*   **Consistent Branding**: The "Biryani Shop" brand is consistently applied across all pages, with a simple and elegant navigation bar.

### 3.2. Features

*   **Dynamic Menu**: The homepage features a menu of biryanis that is dynamically loaded from a SQLite database.
*   **Database Integration**:
    *   Uses Entity Framework Core for all database interactions.
    *   The database schema is managed via "migrations."
    *   The database is seeded with initial data on startup.
*   **Shopping Cart**:
    *   Users can add items to their cart directly from the menu.
    *   A dedicated cart page (`/Cart`) displays the selected items, quantities, and prices.
    *   The cart state is persisted using the user's session.
*   **User Authentication & Authorization**:
    *   Users can create a new account and log in to the application.
    *   The application uses ASP.NET Core Identity for managing users, passwords, and roles.
    *   The navigation bar dynamically displays "Register" and "Login" or "Logout" links based on the user's authentication state.
    *   The database has been updated with the necessary tables for users, roles, and claims.
*   **Admin User Seeding**:
    *   An admin user with the username `milindar.j@ionidea.com` is automatically created when the application starts.
    *   The admin user is assigned to the "Admin" role.
*   **Admin Dashboard**:
    *   A dedicated admin dashboard is available at `/Admin`.
    *   The dashboard is only accessible to users in the "Admin" role.
    *   Admins can view a list of all biriyanis in the database.
    *   Admins can add new biriyanis to the menu through a form on the dashboard.
*   **Checkout and Order Processing**:
    *   Authenticated users can check out their shopping cart.
    *   A new order is created in the database, including order details for each item in the cart.
    *   An `OrderService` encapsulates the business logic for creating orders.
    *   After checkout, the cart is cleared and the user is shown an order confirmation page.
*   **Navigation**: A clean navigation bar provides easy access to the Home page, the Cart, and user account pages. An "Admin" link is visible to logged-in administrators.

## 4. Current Plan: Implement Checkout Functionality

This plan documents the steps that were just completed to add the checkout functionality.

*   **Step 1: Create Order and OrderDetail Models**: Created the `Order` and `OrderDetail` models (`Models/Order.cs`, `Models/OrderDetail.cs`) to represent the database schema for customer orders.
*   **Step 2: Update ApplicationDbContext**: Added `DbSet` properties for `Orders` and `OrderDetails` to the `Data/ApplicationDbContext.cs` file to include them in the EF Core model.
*   **Step 3: Create OrderService**: Created `Services/OrderService.cs` to handle the business logic of creating an order from cart items, separating concerns from the controller.
*   **Step 4: Register OrderService**: Registered the `OrderService` in `Program.cs` to be available for dependency injection.
*   **Step 5: Refactor CartController**: Injected `OrderService` into `Controllers/CartController.cs` and added an `[Authorize]` attribute to the new `Checkout` action, which uses the service to create an order. The `CartItem` model was also updated to include a `Price` property.
*   **Step 6: Create OrderConfirmation View**: Created `Views/Cart/OrderConfirmation.cshtml` to provide feedback to the user after a successful order.
*   **Step 7: Update Cart View**: Updated the cart's `Views/Cart/Index.cshtml` to display item prices, a running total, and a "Checkout" button.
*   **Step 8: Database Migration**: Created and applied a new database migration to add the `Orders` and `OrderDetails` tables to the database.
*   **Step 9: Documentation**: Updated this `blueprint.md` file to reflect the new checkout functionality.
