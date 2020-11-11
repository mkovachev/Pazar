# Pazar Marketplace
<br />
Microservices Architecture with Relational databases (Sql Server) with communicating over RabbitMQ Event Driven Communication and using Ocelot API Gateway.
<br />
### Ads microservice which includes:
ASP.NET Core Web API application 
<br />
REST API principles, CRUD operations 
<br />
Entity Framework Core on SQL Server docker 
<br />
Clean Architecture implementation with CQRS Design Pattern 
<br />
Swagger Open API implementation 
<br />
Dockerfile implementation
<br />
<br />
### Identity microservice:
<br />
ASP.NET Core Web API application
<br />
REST API principles, CRUD operations
<br />
Entity Framework Core on SQL Server docker
<br />
RabbitMQ trigger event queue
<br />
Swagger Open API implementation
<br />
<br />
### RabbitMQ messaging library:
<br />
ASP.NET Core Web API application
<br />
Entity Framework Core on SQL Server docker
<br />
REST API principles, CRUD operations
<br />
Consuming RabbitMQ messages
<br />
Clean Architecture implementation with CQRS Design Pattern
<br />
Event Sourcing
<br />
Implementation of MediatR, FluentValidator, AutoMapper
<br />
Swagger Open API implementation
<br />
Dockerfile implementation
<br />
<br />
---
### API Gateway Ocelot microservice:
<br />
Routing to inside microservices
<br />
Dockerization api-gateway
<br />
<br />
### WebUI ShoppingApp microservice:
Angular
<br />
Run The Project
<br />
You will need the following tools:
<br />
Visual Studio 2019
.NEt 5
Docker Desktop
<br />
<br />
### Installing
<br />
1. Run Start the Docker Desktop
<br />
2. Clone the repository
<br />
3. At the root directory which include docker-compose.yml files, run below command:
<br />
docker-compose -f docker-compose.yml -f docker-compose.override.yml up –d
<br />
4. Wait for docker to compose all microservices. That’s it!
<br />
You can launch microservices as below urls:
<br />
RabbitMQ -> http://localhost:15672/
<br />
Catalog API -> http://localhost:8000/swagger/index.html
<br />
Basket API -> http://localhost:8001/swagger/index.html
<br />
Order API -> http://localhost:8002/swagger/index.html
<br />
API Gateway -> http://localhost:7000/Order?username=swn
<br />
Web UI -> http://localhost:8003/
