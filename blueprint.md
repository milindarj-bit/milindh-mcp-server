
# Project Blueprint

## 1. Overview

This project is a modern, full-stack e-commerce web application for a "Biryani Shop." It is built with .NET and is designed to provide a seamless and visually appealing user experience. The application allows users to browse a menu of biryanis, add them to a shopping cart, and proceed to checkout.

## 2. Style, Design, and Features

### 2.1. Aesthetics & Design

*   **Modern & Clean UI**: The application features a visually balanced layout with clean spacing and polished styles, creating a unique and intuitive user experience.
*   **Responsive Design**: The app is fully mobile-responsive, adapting to different screen sizes to work perfectly on both mobile devices and desktops.
*   **Engaging Visuals**: The site uses a hero section with a compelling headline and a call-to-action to draw users in. The menu is presented in a clear and organized manner.
*   **Consistent Branding**: The "Biryani Shop" brand is consistently applied across all pages, with a simple and elegant navigation bar.

### 2.2. Features

*   **Homepage**: A welcoming hero section that introduces the user to the Biryani Shop.
*   **Menu**: A section on the homepage that displays the available biryanis.
*   **Shopping Cart**:
    *   Users can add items to their cart directly from the menu.
    *   A dedicated cart page displays the selected items, quantities, and total price.
    *   The cart data is stored in the user's session.
*   **Checkout**:
    *   A simple checkout process that clears the cart and displays a confirmation message.
*   **Real-time Updates (SSE)**:
    *   The application includes a Server-Sent Events (SSE) endpoint at `/sse/stream` that streams a list of biryanis in real-time. This can be used for features like real-time order tracking or live menu updates in the future.

## 3. Current Plan: E-commerce Functionality

This plan outlines the steps to add e-commerce features to the Biryani Shop website.

*   **Step 1: Create `blueprint.md`**: Create this file to document the project's features and the current plan.
*   **Step 2: Update `Views/Shared/_Layout.cshtml`**: Add a navigation bar with links to "Home" and "Cart".
*   **Step 3: Update `Views/Home/Index.cshtml`**: Add "Add to Cart" buttons to the menu items.
*   **Step 4: Create `Controllers/CartController.cs`**: Implement the backend logic for the shopping cart and checkout.
*   **Step 5: Create `Views/Cart/Index.cshtml`**: Create the view for the shopping cart page.
*   **Step 6: Create `Views/Cart/Checkout.cshtml`**: Create the view for the checkout confirmation page.
*   **Step 7: Update `Program.cs`**: Add session support to the application.
*   **Step 8: Update `wwwroot/css/site.css`**: Add styling for the new e-commerce components.
