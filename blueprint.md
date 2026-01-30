# Project Blueprint

## 1. Overview

This project is a real-time web application built on ASP.NET Core. Its primary capability is to stream data from the server to the client in real-time using Server-Sent Events (SSE). It's designed to be a simple, robust foundation for building more complex real-time features.

## 2. Project Outline

### Technology Stack

*   **Backend:** C# with ASP.NET Core
*   **Real-time Protocol:** Server-Sent Events (SSE)

### Features & Functionality

*   **SSE Endpoint:** A dedicated controller (`SseController`) provides an event stream at the `/sse/stream` URL.
*   **Real-time Data Stream:**
    1.  Upon connection, the server waits for 2 seconds.
    2.  It sends an initial series of data messages: "Starting up...", "Almost there...", and "Ready!".
    3.  After the initial messages, the server sends a heartbeat comment (`: heartbeat`) every 15 seconds to keep the connection alive.
*   **Hosting:** The application is configured to run on `http://0.0.0.0:8081` to avoid conflicts with the development environment's default port.

### Design & Style

*   Currently, the project is backend-focused. No specific frontend design or styling has been implemented.

## 3. Current Plan: Create a Frontend for SSE Visualization

The backend is now stable and correctly streaming data. The next step is to create a user interface to consume and display this data.

### Goal

Build a simple, clean web page that connects to the SSE endpoint and displays the messages received from the server in real-time.

### Action Steps

1.  **Create `index.html`:** An HTML file will be created in the `wwwroot` directory to serve as the application's user interface.
2.  **Add JavaScript for EventSource:** A `<script>` tag will be added to `index.html` containing JavaScript to:
    *   Instantiate an `EventSource` object pointing to the `/sse/stream` endpoint.
    *   Listen for the `message` event.
    *   Append the received data to a list on the page.
3.  **Update `Program.cs`:** Configure the application to serve `index.html` as the default file for the root URL (`/`).
4.  **Basic Styling:** Apply simple CSS to ensure the displayed messages are clear, readable, and have a visually appealing layout.
