# Play

## Description

This project is a collection of services and frameworks designed to facilitate communication between the Catalog and Inventory services throughout REST APIs. It includes the following components:

- **Play.Infra**: Contains the `docker-compose.yaml` file to help develop and run the application locally.
- **Play.Frontend**: A simple template for the frontend, which uses the Catalog and Inventory services and is written in Node.js.
- **Play.Common**: A simple framework that initializes the connection to MongoDB and helps communicate between the Catalog and Inventory services.
- **Play.Inventory**: Defines the Inventory Entities and its Services. Has the following routes:
+ GET /items/
+ POST /items/
- **Play.Catalog**: Defines the Catalog Entities, its Contracts, and its Services. Has the following routes:
+ GET /items/
+ POST /items/
---
+ GET /items/:id
+ PUT /items/:id
+ DELETE /items/:id

## Why?

The motivation behind this project is to provide a clear and concise documentation for users and contributors.

## Quick Start

To get started with this project, follow these steps:

1. Install `.NET 7.0`, `Docker` to your machine
2. Clone the repository
3. Open an terminal however you want, in these folder:
- Play.Infra
4. Run the command "docker compose up -d" in the above terminal. (when you have done, please run "docker compose down" in the same terminal)
5. Open an terminal however you want, in these folders:
- Play.Inventory\src\Play.Inventory.Service
- Play.Catalog\src\Play.Catalog.Service
6. Run the command "dotnet run --launch-profile https" in both of the above terminal. (when you have done, please type Ctrl+C in both of the terminals)
7. Open an terminal however you want, in these folder:
- Play.Frontend
8. Run the command "npm start" in the above terminal. (when you have done, please type Ctrl+C in the terminal)
9. Open your desired browser, navigate to `http://localhost:3000`.
10. You should be able to explore from here.


## Usage

Here are examples of how to use this project:

- Use Postman to test how Catalog (`localhost:7205`) and Inventory (`localhost:7201`) services interacts with each other throughout their APIs.
- Remember to use it with RabbitMQ (`localhost:27017`) for additional information!

## Contributing
freeCodeCamp has guided me throughout this project, so remember to check them out for their detailed & quality tutorial 🎉

We welcome contributions from the community. To contribute, follow these steps:

1. Fork the repository.
2. Create a new branch.
3. Make your changes.
4. Submit a pull request.
