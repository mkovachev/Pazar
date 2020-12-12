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
- Angular 11 communication with the backend API + Jwt Auth
#### How to run the app
1. You will need .NET 5 and Docker Desktop installed
2. Clone the repository
3. Open your command shell at the root directory which include docker-compose.yml file and run the following command: docker-compose up -d
4. Wait for docker to compose all microservices. That’s it! :blush:
##### Once the above steps are done, click the url: http://localhost:80
