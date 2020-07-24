## Bike Store RESTful API with ASP.NET Core

This project allows a customer to buy a bike from our store.

## Used frameworks and libraries

* Entity Framework Core
* AutoMapper
* Swagger

## Implemented design patterns
*  Unit of work
*  Request-Response
*  Dependency injection
*  Repository

## Implemented Concepts
* Retry policy with poly (BikeStoreClient\Handlers\RetryPolicyDelegatingHandler.cs)
* Cancellation tokens (BikeStore - Project\Controllers\BikesController.cs)
* In-memory caching (BikeStore - Project\Data\Persistence\Repositories\BikeRepository.cs)
* Testing demo (BikeStoreTest\BikeTest.cs)
* eTAg (BikeStore - Project\Controllers\BikesController.cs)
* Database seeding (BikeStore - Project\Data\Persistence\AppDbContext.cs)
* Consume api routes(post/get/update/delete- BikeStore - Project\BikeStoreClient\Controllers\BikesConsumerController.cs)
* Extension methods
* Identity Server
* Enums
* Global exception handler
* Middlewares 
* Logger
* Models
* Validation
* Reflection

## Documentation links
* https://www.tutorialspoint.com/csharp/csharp_reflection.htm

