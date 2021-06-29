# Sprint: SPRINTNAMEHERE (29.06.2021 - 09.07.2021)


## Features/Stories/Tasks

* Feature: define REST resource/create domain models
  - Story: Create the product domain model  

* Feature: Setup Aspnet core backend  
  - Story: As a frontend system I want a backend server    
Create a new dotnet webapi with the command: "dotnet new webapi"  
https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-5.0&tabs=visual-studio  
Create a test project for unit/integration tests (See BasicWebApi.Test.csproj)  
https://fluentassertions.com/introduction  
  - Story: Setup database with efcore  
Create an entityModel to save in the database/table  
Create a DbSet(efcore) for the model  
https://docs.microsoft.com/en-us/ef/core/  

* Feature: Implement CRUD for resource product
  - Story: As a system I want to CREATE products  
Create a controller method for posting products  
Create contract types for the model (Create/view model)  
Create a service method for saving the product to a database
  - Story: AS a system I want to UPDATE products  
Create a controller method for putting products  
Create a contract type for updatemodel  
Create a service method for updating the product in a database  
  - Story: As a system I want to DELETE products  
Create a controller method for deleting products  
Create a service method for deleting the product in a database
  - Story: As a system I want to READ   products  
Create a controller method for getting all products   
Create a controller method for getting one specific product    
Creata a service method for getting all products from the database  
Creata a service method for getting a specific product from the database  
    

* Feature: Host vue.js app with dotnet core  
  - Story: As a Developer I want to host my front-end within the dotnet core api  
Configure the aspnet core api to host js-frontend(vue)   
Configure the front-end to send request to aspnet api(instead of express)  
