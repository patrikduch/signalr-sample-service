# signalr-sample-service

## dependencies

<ul>
    <li>Automapper</li>
    <li>Dapper MicroORM</li>
    <li>EFCore</li>
    <li>NET 5</li>
    <li>SignalR</li>
<ul>


## dockerization

### build image

docker build -f Dockerfile -t signalr-sample-service .

### run image

docker run -p 8080:8080 signalr-sample-service 

## development


### dependencies

<li>RabbitMQ portal</li>
http://localhost:15672/#


### app startup

docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d


## data layer

### add migration

add-migration CompanyEntity -Project SignalRSampleService -Context CompanyContext

### save changes (migrate to the new version)

Update-Database -Project SignalRSampleService -Context CompanyContext



