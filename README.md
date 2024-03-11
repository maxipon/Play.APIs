# Play

## Description

This project is a collection of services and frameworks designed to facilitate communication between the Catalog and Inventory services throughout REST APIs. It includes the following components:

- **Play.Infra**: Contains the `docker-compose.yaml` file to help develop and run the application locally.
- **Play.Frontend**: A simple template for the frontend, which uses the Catalog and Inventory services and is written in Node.js.
- **Play.Common**: A simple framework that initializes the connection to MongoDB and helps communicate between the Catalog and Inventory services.
- **Play.Inventory**: Defines the Inventory Entities and its Services.
- **Play.Catalog**: Defines the Catalog Entities, its Contracts, and its Services.

## Why?

The motivation behind this project is to provide a clear and concise documentation for users and contributors.

## Quick Start

To get started with this project, follow these steps:

1. Install .NET 7.0
2. Clone the repository
3. Open an terminal however you want, in these folders:
- Play.Inventory\src\Play.Inventory.Service
- Play.Catalog\src\Play.Catalog.Service
5. Run the command "dotnet run --launch-profile https" in the terminal for both of the above terminal.
6. Open an terminal however you want, in these folders:
- Play.Frontend
7. Run the command "npm start" in the terminal for both of the above terminal.
8. Open your desired browser, navigate to http://localhost:3000.
9. You should be able to explore from here.

## Usage

Here are some examples of how to use this project:

- Example 1: Use Postman to test how Catalog and Inventory services interacts with each other. Remember to use it with RabbitMQ (you can navigate to localhost:27017) for additional information!

## Contributing
freeCodeCamp has guided me throughout this project, so remember to check them out for their detailed & quality tutorial 🎉

We welcome contributions from the community. To contribute, follow these steps:

1. Fork the repository.
2. Create a new branch.
3. Make your changes.
4. Submit a pull request.
