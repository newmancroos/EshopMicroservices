# EshopMicroservices

### Cache-Aside Pattern for Microservices :

The “Cache-Aside Pattern” is a way to manage data caching to improve system performance. When an application needs data, it first checks the cache. If the data is there a cache hit, it is used right away. If not a cache miss, the application fetches the data from the main database, stores a copy in the cache, and then uses it. This pattern helps reduce database load and speeds up data retrieval. It’s commonly used to enhance the efficiency and scalability of applications by making frequently accessed data quickly available.

How it Improves System Performance?

The Cache-Aside Pattern improves system performance by leveraging the speed and efficiency of in-memory caching to reduce the load on the main database and accelerate data retrieval. Here’s how it enhances performance:

Faster Data Access: Accessing data from memory (cache) is significantly faster than retrieving it from disk-based storage (database). By storing frequently accessed data in the cache, the pattern ensures that subsequent requests for the same data can be served rapidly, leading to quicker response times and a smoother user experience.

Reduced Database Load: By diverting a significant portion of read requests to the cache, the pattern decreases the number of direct queries to the database. This reduction in database queries lowers the overall load on the database, allowing it to perform more efficiently and reducing the risk of bottlenecks, especially under high-traffic conditions.

Scalability: As the demand on the system increases, the cache can handle a large volume of read requests without putting additional strain on the database. This makes the system more scalable, as it can accommodate more users and higher data request rates without degrading performance.

Improved Throughput: By offloading data retrieval tasks to the cache, the database is freed up to handle other operations, such as write requests or more complex queries. This improves the overall throughput of the system, enabling it to process a greater number of transactions or operations within a given time frame.

Decreased Latency: The pattern minimizes the latency associated with data retrieval by serving cached data. This is particularly beneficial for applications where low latency is crucial, such as real-time systems or high-frequency trading platforms.



How Cache-Aside Works

Cache-Aside, also known as Lazy Loading, is a popular caching pattern in system design used to improve the performance and efficiency of data retrieval operations. Here’s how it works, step-by-step:

How-Cache-Aside-Works

![image](https://github.com/user-attachments/assets/f67f39b0-b766-4cc3-9d40-c39c8e9bd182)


### The Proxy design pattern

The Proxy design pattern is a structural design pattern that provides a surrogate or placeholder for another object to control access to it. This pattern is useful when you want to add an extra layer of control over access to an object. The proxy acts as an intermediatory, controlling access to the real object.


![image](https://github.com/user-attachments/assets/c1227e5b-0be3-48db-beda-0e526815a5a5)


### The Decorator Pattern

The Decorator Design Pattern is a structural design pattern used in software development. It allows behavior to be added to individual objects, dynamically, without affecting the behavior of other objects from the same class. This pattern is useful when you need to add functionality to objects in a flexible and reusable way.

This pattern is vital for enhancing functionality while adhering to the open-closed principle. To gain insights into design patterns and their application in system architecture, consider enrolling in the System Design Course, which covers various patterns and their implications for system design.

![image](https://github.com/user-attachments/assets/f834e4d2-e934-478e-bde9-9f1102bbbc10)


### Scrutor Library

.Net library that extends the build-in IOC container of ASP.NET Core. It provides additional capabilities to scan and register services in a more flexible way.

#### Usages:
  Implementing patterns like Decorator in a clean and manageable way. It simplifies the process of service registration and decoration in ASP.NET Core application.

### Implement Decorator Pattern sing Scrutor Library
1. Define Interface & Base Implementation
   * Start with an interface eg. IBasketRepository, and a base implementation eg. BasketRepository

2. Create Decorator
   * Create a decorator class like CachedBasketRepository that also implements IBasketRepository but adds caching logic.

3. Register Service with Scrutor:
    * Use Scrutor in Program.cs to first register the base service (BasketRepository) and then apply the decorator(CachedBasketRepository).

ex.
    builder.Services.AddScoped<IBasketRepository,BasketRepository>();
    builder.Service.Decorate<IBasketRepository, CachedBasketRepository>();

    


## gRPC
	- gRPC is an open source remote procedure call system developed by google
	- gRPC is a framework to efficiently connect services and build distributed systems
	- It is focusing on high performance and uses the HTTP/2 protocol to transport binary messages
	- It is relies on the Protocol Buffer language to define service contracts.
	- Protocol Buffer (Protobuf), allow to define the interface to be used in service to service communication regardless of hte programming.
	- It is both Synchronus and Asynchronus
	- Once you define a contract with Protobuf, this contract used by each service to automatically generate the code that sets up the communication infrastructure.
	- gRPC is a form of Client-Server communication that uses function call rather than usual HTTP call.
	- In gRPC, client application can directly call a method on a server application on a different machine like a local object
	- On the server side, the server implements this interface and runs a gRPC server to handle client calls
	- On client side, the client has a stub that provide the same methodss as server
	- gRPC clients and servers can work and talk to each other in a different of environments.


 ## How to create Grpc application:
1. Create proto file and define service and messages
![image](https://github.com/user-attachments/assets/d6018e9f-d0a6-4c95-a09a-a4652df928a4)

2.  Compile the grpc service will generates grpc C3 classes in obj/net8.0/protos directory
   ![image](https://github.com/user-attachments/assets/31a7be5f-6904-42d0-9920-c32a8ff92210)

4. Create actual service class and inherite proto class base in service class
![image](https://github.com/user-attachments/assets/23e0140c-a783-40f7-85fc-f2355788d0c3)

5. Map service in the prpgram.cs
![image](https://github.com/user-attachments/assets/ef0584ab-86c2-4a7b-9db9-94f168badd0b)

    
 ### Clean Architecture:

 It is also call Domain centric architechture.

 ![image](https://github.com/user-attachments/assets/ca55877a-2d60-48e3-959d-a8f950fdc673)

![image](https://github.com/user-attachments/assets/03b007c4-bbc2-4fb3-8fa0-18fb313fa327)


![image](https://github.com/user-attachments/assets/11da48cd-c40f-40bb-9296-4b8503b994f1)

![image](https://github.com/user-attachments/assets/ee0a7cc3-7b20-40b2-bded-f501684c240b)

![image](https://github.com/user-attachments/assets/bde654ff-2a53-4afb-9976-f17480cef08a)

![image](https://github.com/user-attachments/assets/20b59bbd-ff83-4a4c-b86e-53a5c52d3e80)



### Aggregate/Value Objects:

![image](https://github.com/user-attachments/assets/1ad65151-9221-40d7-b586-8c294bc4efa2)




 ### Primitive Obsession:
 - Primitive Obsession is a code smell where primitives (string, int, Guid) are used for domain concepts, leading to ambiguity and error
 - Example using Guid for OrderId, CustomerId and ProductId we may pass CustomerId for ProductId
 - Solution : Using Strongly type Id that means create OrderId object and pass it for OrderId.

<hr/>

### Anemic-Domain Model Entity:
- Entity have little or no business logic (domain logic)
- Essentially data structure with getters and setters
- But the business rules and behaviors are typically implemented outside the entity, often in service layer.
- Ex.
  <pre>
	  public class Order
	  {
	  	Public List<OrderItem> OrderItem {get;set;}
	  }
  </pre>
  Here We can fill OrderItem directly to this instance of the class

### Rich-Domain Model Entity:
- Entity encapsulate both data and behavior.
- This model enriches entities with methods that embosy business rules and domain logic
- Ex.
  <pre>
	public class Order
	  {
	  	private readonly List<OrderItem> _orderitems = new();
		public IReadonlyList<OrderItem> OrderItems => _orderiItems.AsReadOnly();

		public void AddOrderItem(OrderItem item)
		{
			//logic
		}
		public void RemoveOrderItem(OrderItem item)
		{
			//logic
		}	
	  }
  </pre>
  -Order is a rich domain model as it includes methods AddOrderItem and RemoveOrderItem which encapsulates the business logic for manipulating the order items.
<hr/>

### Domain Event in DDD

- Domain Events represent somthing that happened in the past and the other part of the same service bountry same domain need to react to those changes
- Domain Event is a business event that occures within the domain model. It often represents a side effect of a domain operaation
- Achive consistency between aggregates in the same domain.
- When an order is placed, an OrderPlace event might be triggered.
- Triggere side effects or notify other parts of the system about changes within the domain

<b>How to use Domain events in DDD?</b>

- Encapsulate the event details and dispatch them to the interested parties
- Communicate changes within the domain to external handlers which may perform actions based on these events.

  ![image](https://github.com/user-attachments/assets/0f041549-0826-46ac-9382-86b5d35c36a0)

![image](https://github.com/user-attachments/assets/828e7c4f-1d85-4118-a616-7e7a96951620)


### Integrated Events

-Integrated events are used for bringing domain stae in sync across multiple microservices, or external system.
The purpose of the integration events is to propagate committed transactions and updates to additional sub-systems, with different services (it can be microservices, bounded context, or external applications).

Let’s assume again, we have an e-commerce application and have some services, such as Order MS, Catalog MS, Basket MS, and so on…

What we should do when a product price is updated? How we can reflect this change to a basket with the product which its price updated?

![image](https://github.com/user-attachments/assets/4f4940dc-b983-4d2d-ac99-e1cf03988181)


If a product price is updated in the Catalog Microservice, we should check the existing basket items in the Basket Microservice and update the same product price - reflect the same change in the basket service - and this can be achieved by publishing an integration event in the Catalog Microservice and handling the event in the Basket Microservice asynchronously.


### Domain Vs Integrated Events

* <u>Domain Events</u>
- Publish and consume within a single domain. Strictly within the bountry of the microservice/domain context
- Indicate something happened within the aggregate.
- In-process ans synchronusly, sent using an In-Memory message bus
- Ex. OrderPlacedEvent

* <u>Integrated Events</u>
- Used to communicate state changes or events between context or microservices
- Overall system's reaction to certain domain events
- Asynchronusly sent with a message broker over a queue
- Ex. After handling OrderPlacedEvent, an OrderPlacedIntegrationEvent might be published to a message broker like RabbitMq then consumes by other microservices.


![image](https://github.com/user-attachments/assets/04e04f4b-08c3-4131-a2ec-1c96a2bee837)


### Entity Framework

Tooling for EF Core migration and reverse engineering (Scaffolding) from an existing datbase has 2 ways.

1. .NET Core CLI:
   	dotnet-ef and Microsoft.EntityFrameworkCore.Design for cross-platform command line tooling
   	* dotnet tool install --global dotnet-ef
   	* dotnet add package Microsoft.EntityFrameworkCore.Design
2. Package Manager Console (PMC) in Visula Studio:
   	* Microsoft.EntityFrameworkCore.Tools for Powershell tooling that works in the Visual Studio Package Manager Console
   	   - install-Package Microsoft.EntotyFrameworkCore.Tools
   	 
   	
### ValueObject Mapping with ComplexType and Complexproperty

- EF Core 8, "Complex Types" are introduced to better support <b>value object</b> in DDD.
- Complex Type is an object that does not have a primary key and is used to represent a set of properties in an entity.

Example of Complex types (Value Objects):

- Address can be a complex type representing the shiping and billing addresses for an Order. and Configuring Complex type in OnModelCreating :
  ![image](https://github.com/user-attachments/assets/99da130d-6a57-48d1-a2f9-1dc6b779d048)
  
### EF Migration

- We need to Add Microsoft.EntityFrameworkCore.Design
- add-migration InitialCreate -OutputDir Data/Migrations -Project Ordering.Infrastructure -StartupProject Ordering.Api

### What is Owns entity?

An Entity may have set of same fields that can be used to other entities too for example Address entity can be used in mjultiple entities but it has no separate table. so The entity that has Address entity called entity owned the address entity.

https://dev.to/kashifsoofi/entity-framework-core-owned-entity-clk

### CQRS and Event Sourcing

Command Query Responsibility Segregation (CQRS) is a design pattern that segregates read and write operations for a data store into separate data models. This allows each model to be optimized independently and can improve performance, scalability, and security of an application.

Event Sourcing is the pattern that hold every stage/state of the data stored into the database that means, when we edit a record it will not overwrite but maintain different copy of data and create materialized view for reading the data.

![image](https://github.com/user-attachments/assets/81257503-2e47-467d-9162-08b46e97567f)

### Eventual Consistency Principal
- CQRS with Event sourcing pattern leads Eventual Consitence.
- Eventual Consistency is especially used for systems that prefer high availability to strong consistency
- The system will become consisyent after a certain time
- we called this latency is Eventual Consitence principal and offers to be consistenct after a certiain time.
- There are 2 types of Consistency level
  	* Strict Consistency : When we save data, the data should be affect and seen immediatly for every client. ex. Deposits in bank immediatly available to the client
  	* Eventual Consistency : When we write any data, it will take some time for the clients reading the data. ex. Video context, create video classes may take time to reach to the clients
 
  ## CQRS and Event Sourcing Patterns:
  	- When user perform any action into application, this will save actions as an event into Event store
  	- Data will convert to Reading database with follwing the publish/subscribe patter with using message brokers.
  	- Data will be denormalized into materialized view database for quering from the application
  	- 


### RabbitMQ

- It is a message brocker using AMQP (Advance Message Queuing Protocal) to trasmitting the message
- Main components of RabbitMq are:
  	- Producer
  	- Queue
  	- Consumer
  	- Message
  	- Exchnage
  	- Binding

  ![image](https://github.com/user-attachments/assets/9bebd600-119c-4c08-8b70-6ac77f3156aa)


  - Excchange is the structure that decide which queue to send messages.
  - Binding are link between the Exchange and the Queue
  - Exchange types <br/>
    	- Direct Exchange   - Uses of single queue is being addresses, Routing key determine the queue <br/>
    	- Topic Exchange  - Messages are sent to different queues according to their subject. Incoming messages classified and send to the related queues. It is varient of the Publish/Subscribe pattern <br/>
    	- Fanout Exchange - Broadcasting system, Messages will be sent to all the queues related to the exchange <br/>
    	- Header Exchange - Guided by the feature added to the header of the message. Routing key used in other models is not uses. Attributes of the header and queue should be match <br/>
    

### Dual Write Problem
- When application need to change data in two different system, (i.e: Change data in database and send message to message brocker) If one of the write failes, it can result in inconsustent data is called Dual write problem

- We can solve this problem by imple,menting Outbox pattern.
- In Outbox pattern, there will be two table for a transaction, 1. the actual table and apother one for Outbox tracking table. Instead of sending directly to the mesage bus we write the message into Outbox table under same transaction, if there is any problem both table will be rolled back.
  There should be a separate listerner service/background process read outbox table and send the message. 

### Domain Event VS Integration Event

- Domain event happens within a domain ie, Within a project example Order created event is hapenning within Order microservice. It may happen within a aggregate without out using message service may use MediatR Notification (Im-memory message bus)

- Integration Event is across microservices example with Baskt checkout it will raise a integration event using RabbitMq and Order microservice will consume it and process the order

  ### Asp.Net Feature Management for Feature Flags
  - Feature Falgs are powerful technique, allowing teams to modify system behavior without changing the code
  - They enable functionalities to be turned on or off dynamically, providing flexibility in deployment and testing
  - ASP.NET core supports feature management, integrating seamlessly with the existing configuration system.
  - Microsoft.FeatureManagement.AspNetCore : A Nuget package that offers a streamlined approach to implement feature flags.


### Proxy Vs Reverse Proxy
A proxy server acts as an intermediatry between a user and the internet, while a Reverse proxy sits in front of web servers to inspect incoming request.
## <u>Proxy Server</u>
- Acts as a gateway between users and internet
- Protect users from malicius activity on the internet
- Can route and filter employee tracffic to the public internet
- Can provide varying level of functionality, Secure and privacy

## <u>Reverse Proxy</u>
- Intercept and inspect incoming client requests before forwarding wethem to the web server
- Can handle multiple requests for the same site, distributing them to different servers
- Can cache web content to improve loading time
- Can support load balancing, traffic filtering, IP address concealment and DDos attck protection

  ![image](https://github.com/user-attachments/assets/1b394540-abe2-47e3-a244-ba65fb0120f1)


### Gateway routing Pattern
- Route requests to multiple microservices with exposing a single endpoint
- Useful when expose multiple services on a single endpoint and route then to internal backend microservices based on the request
- The client needs to consume several microservices, gateway route pattern offers to create a new endpoint that handle the request and route this request for each services
- If one of microservices are changed, the client doesn;t know anything and not need to change any code on client side, the only changes will be configuration route changes.

![image](https://github.com/user-attachments/assets/8ed8399b-0468-445d-868a-1719b5f2f98d)

### API Gateway Pattern
- API Gateway is a single point of entry to the client applications, sits between the client and multiple backend.
- API Gateway manage route to internal microservices and able to aggreate several microservices request in 1 response and handle cross-cutting concerns.
- Provides a reverse proxy to redirect or route requests to your internal microservices endpoints.
- Serveral client applications connect to a single API gateway possible Single-Point-of-failure risk.
- If these client applications increase or adding more logic to business complexity in API Gateway, it would be anti-pattern.

![image](https://github.com/user-attachments/assets/2c6f00d2-0321-4a69-b277-b348632a6bd0)


### Main feature of API gateway Pattern
- Reverse Proxy and gateway Routing
- Request Aggregation and Gateway Aggrigation (Aggregate multiple internal microservices into single client request / Aggregate multiple result from mulriple apis into one response and send back to client.
- Cross-cutting Concern (Authentication, Authorization, Service discovery, response caching, Retry policies, Load Balancing, Logging and tracing

### Backends for Frontends pattern (BFF)
- For complex application, having single Gateway nakes a Single-point-of failure
- So we can have multiple Gateway so Client applications can communicate different gateways.

![image](https://github.com/user-attachments/assets/cc222309-5266-4b44-ac94-a17e36529b91)


### Microsoft Reverse Proxy : YARP

- YARP is a lightweight higly customizable reverse proxy solution developcrosoft, tailorded for .NET application
- Designed to integrate seamlessly with .NET Core, making it easy to add to existing .Net project
- Simplyfy the routing of requests to different backend services, offering capabilities for request transformation, load balacing and more.
- Features
	- <b>Customozable routing rules</b>
 	- <b>Cross-Platform</b> : YARP is build for .NET, making it cross-platform. It can run on any platform that support .NEt Core, including Windows, Linux and macOS
  	- <b>Support for Latest Protocols</b> : YARP supports mordern networking protocols incliding gRPC, HTTP/2 and WebSockets
  	- <b>Great perofrmance</b>
  	- <b> Health Checks <b/> : Movitors the health of backend services and reroiutes traffic as needed.  
