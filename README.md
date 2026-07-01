# CodeShareClone

This is a code sharing application built with ASP.NET Core, SignalR, and SQLite.

## Features

- Real-time code sharing and synchronization using SignalR.
- SQLite database for storing code snippets.
- MVC architecture.

## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download) (or compatible version).

### Setup

1.  **Clone the repository:**
    ```bash
    git clone <repository_url>
    cd CodeShareClone
    ```

2.  **Restore dependencies:**
    ```bash
    dotnet restore
    ```

3.  **Apply Migrations:**
    ```bash
    cd CodeShareClone
    dotnet ef database update
    ```

4.  **Run the application:**
    ```bash
    dotnet run
    ```
    The application will typically run on `https://localhost:5001` or `http://localhost:5000`.

## Technologies Used

- ASP.NET Core MVC
- SignalR
- Entity Framework Core (SQLite)
- HTML/CSS/JavaScript (Frontend)
