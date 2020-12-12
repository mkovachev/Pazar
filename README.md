# Pazar Marketplace
Event-Driven Microservice Architecture with Jwt Authentication + MS SQL Server + Docker + Rabbitmq + Hangfire + CronJobs
#### Identity microservice:
- ASP.NET Core Web API application - CRUD on all users
- Swagger UI + Auth Jwt
#### Ads microservice:
- ASP.NET Core Web API application - CRUD on all ads
- Swagger UI + Auth Jwt 
#### Notifications microservice:
- ASP.NET Core Web API application - route messages to respective microservice
#### Statistics microservice:
- ASP.NET Core Web API application - shows Ads statistics
- Swagger UI + Auth Jwt
#### Watchdog microservice:
- ASP.NET Core Web API application - health monitoring of all microservices
#### WebUI Angular app
#### How to run the app
1. You will need .NET 5 and Docker Desktop
2. Clone the repository
3. At the root directory which include docker-compose.yml files, run below command: docker-compose up -d
4. Wait for docker to compose all microservices. That’s it!
##### You can launch Web UI as below urls: http://localhost:80
