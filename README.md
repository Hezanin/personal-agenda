# Personal Agenda

An ASP.NET Web API that manages all transactions for the personal agenda information of users. 

## Table of Contents

- [Overview](#overview)
- [Architecture](#architecture)
- [Setup](#setup)

## Overview

This ASP.NET Web API project serves as the backend for the personal agenda information of a user, such as saving shopping, meeting and meetup activites. It follows a layered architecture consisting of domain, data access, and API layers. The domain layer contains the core business logic and domain models, while the data access layer utilizes Entity Framework Core for interacting with a SQL Server database. The API layer provides HTTP endpoints for clients to interact with the backend services.

## Architecture

### Domain Layer

The domain layer contains the core business logic and domain models of the application. Here is where i defined the user and the user's possible agenda activities: meeting, shopping and meetup.

### Data Access Layer

Using a code-first approach, the data access layer interacts with the SQL Server database using Entity Framework Core. It handles CRUD operations and database migrations.

### API Layer

A work in progress :)

## Setup

1. **Clone the Repository**: using Git:

    ```
    git clone https://github.com/Hezanin/personal-agenda.git
    ```

2. **Install Dependencies**: Navigate to the project directory and install dependencies using the .NET CLI:

    ```
    dotnet restore
    ```

3. **Database Setup**: Configure the connection string in the `appsettings.json` file to point to your SQL Server database. Apply EF Core migrations to create or update the database schema:

    ```
    dotnet ef database update
    ```

