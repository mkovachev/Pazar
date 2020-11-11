# Pazar Marketplace
<br />
Microservices Architecture with Relational databases (Sql Server) with communicating over RabbitMQ Event Driven Communication and using Ocelot API Gateway.

<br />
### Ads microservice which includes: <br />
ASP.NET Core Web API application <br />
REST API principles, CRUD operations <br />
Entity Framework Core on SQL Server docker <br />
Clean Architecture implementation with CQRS Design Pattern <br />
Swagger Open API implementation <br />
Dockerfile implementation <br />
<br />
### Identity microservice:
ASP.NET Core Web API application
REST API principles, CRUD operations
Entity Framework Core on SQL Server docker
RabbitMQ trigger event queue
Swagger Open API implementation
Dockerfile implementation
<br />
### RabbitMQ messaging library:
ASP.NET Core Web API application
Entity Framework Core on SQL Server docker
REST API principles, CRUD operations
Consuming RabbitMQ messages
Clean Architecture implementation with CQRS Design Pattern
Event Sourcing
Implementation of MediatR, FluentValidator, AutoMapper
Swagger Open API implementation
Dockerfile implementation
<br />
### API Gateway Ocelot microservice:
Routing to inside microservices
Dockerization api-gateway
<br />
### WebUI ShoppingApp microservice:
Angular
<br />
Run The Project
You will need the following tools:
<br />
Visual Studio 2019
.NEt 5
Docker Desktop
<br />
### Installing
1. Run Start the Docker Desktop
2. Clone the repository
3. At the root directory which include docker-compose.yml files, run below command:
docker-compose -f docker-compose.yml -f docker-compose.override.yml up –d
4. Wait for docker to compose all microservices. That’s it!
<br />
You can launch microservices as below urls:
<br />
RabbitMQ -> http://localhost:15672/
Catalog API -> http://localhost:8000/swagger/index.html
Basket API -> http://localhost:8001/swagger/index.html
Order API -> http://localhost:8002/swagger/index.html
API Gateway -> http://localhost:7000/Order?username=swn
Web UI -> http://localhost:8003/
