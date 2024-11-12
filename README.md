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
