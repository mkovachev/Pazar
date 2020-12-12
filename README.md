# Pazar Marketplace
Event-Driven Microservice Architecture + MS SQL Server + Docker + Rabbitmq
#### Identity microservice:
- ASP.NET Core Web API application - CRUD on all users
- Swagger Open API
#### Ads microservice:
- ASP.NET Core Web API application with CRUD on all ads
- Swagger Open API 
- RabbitMQ event queue
#### Notifications microservice:
- ASP.NET Core Web API application - to pass the messages btw microservices
#### Statistics microservice:
- ASP.NET Core Web API application - shows Ads statistics
- Swagger Open API
#### Watchdog microservice:
- ASP.NET Core Web API application - health monitoring of all microservices
#### WebUI Angular app
#### How to run the app
1. You will need .NET 5 and Docker Desktop
2. Clone the repository
3. At the root directory which include docker-compose.yml files, run below command: docker-compose up -d
4. Wait for docker to compose all microservices. That’s it!
##### You can launch Web UI as below urls: http://localhost:80
![Image of Home] (C:\Users\kovachma\Desktop)
![Image of Home] (MyAds.PNG)

