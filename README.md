# Pazar Marketplace
Event-Driven Microservice Architecture + MS SQL Server + Docker + Rabbitmq
#### Ads microservice includes:
- ASP.NET Core Web API application with CRUD on all ads
- Swagger Open API implementation 
- RabbitMQ trigger event queue
#### Identity microservice:
- ASP.NET Core Web API application - CRUD on all users
- Swagger Open API implementation
#### WebUI Angular app
#### How to run the app
1. You will need .NET 5 and Docker Desktop
2. Clone the repository
3. At the root directory which include docker-compose.yml files, run below command: docker-compose up -d
4. Wait for docker to compose all microservices. That’s it!
<br />
You can launch Web UI as below urls: http://localhost:80

