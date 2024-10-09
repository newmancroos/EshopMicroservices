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

    
