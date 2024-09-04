# Technology News Portal Api

## Overview

This project is a web-based portal designed to manage technology news. The API handles various operations related to news categories, authors, and news content.

## Requirements

- .NET Framework 4.7.2 or higher
- SQL Server 2016 or later

## Features

- **News Management:** Create, update, and delete news articles.
- **Category Management:** Manage categories under which news articles are published.
- **Author Management:** Manage author details including personal information and specialization.

## Used Technologies

- **ASP.NET MVC:** The framework used for the web application.
- **Entity Framework:** ORM tool used for database operations.
- **SQL Server:** Relational database management system used for data storage.
- **Bootstrap:** Front-end framework used for responsive design.

## Project View

![Database Schema](https://github.com/user-attachments/assets/9c654675-ce71-4fde-84ca-cc9082146f8f)

### Folder Structure

```bash
├── App_Start
│   └── RouteConfig.cs    # Defines the routing configuration
├── Content
│   ├── bootstrap.css     # CSS framework for styling
│   └── site.css          # Custom styles for the application
├── Controllers
│   ├── HomeController.cs # Manages the home page logic
│   ├── NewsController.cs # Handles operations related to news articles
│   └── AuthorController.cs # Manages author-related operations
├── Models
│   ├── News.cs           # Represents the news entity
│   ├── Category.cs       # Represen
