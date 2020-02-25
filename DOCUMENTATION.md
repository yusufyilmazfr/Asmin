# Welcome to Asmin Documentation. 🎉🎉
### You can get information about the project structure in this documentation. Here we go. 🥳




- [Connection String](#connection-string "Connection String")
-  [Entity Layer Definitions](#entity-layer-definitions "Entity Layer Definitions")
- [Data Access Layer Definitions](#data-access-layer-definitions "Data Access Layer Definitions")
- [Business Layer Definitions](#business-layer-definitions "Business Layer Definitions")
  - [ Method Signature](#method-signature " Method Signature")
- [Defining the Dependencies of Business and Data Access Layer](#defining-the-dependencies-of-business-and-data-access-layer "Defining the Dependencies of Business and Data Access Layer")
	 - [Introducing Dependency Modules to the Web or API](#introducing-dependency-modules-to-the-web-or-api "Introducing Dependency Modules to the Web or API")
- [Entity Validation Rules](#entity-validation-rules "Entity Validation Rules")
- [Core Layer Definitions](#core-layer-definitions "Core Layer Definitions")
 	- [Aspect Oriented Programming](#aspect-oriented-programming "Aspect Oriented Programming")
	 	- [Authorization Aspect](#authorization-aspect "Authorization Aspect")
		 - [Cache  Aspect](#cache-aspect "Cache  Aspect")
		 - [Cache Remove Aspect](#cache-remove-aspect "Cache Remove Aspect")
	 	- [Unit Of Work Aspect](#unit-of-work-aspect "Unit Of Work Aspect")
	 	- [Exception  Aspect](#exception-aspect "Exception  Aspect")
	 	- [Log Aspect](#log-aspect "Log Aspect")
 	- [How Do Write Custom Aspect](#how-do--write-custom-aspect "How Do Write Custom Aspect")
 	- [Working Order of Aspects](#working-order-of-aspects "Working Order of Aspects")
 	- [Cross Cutting Concerns](#cross-cutting-concerns "Cross Cutting Concerns")
		 - [Cache Service](#cache-service "Cache Service")
 	- [Hash Service](#hash-service "Hash Service")
- [Defining the Dependencies of Core Layer](#defining-the-dependencies-of-core-layer "Defining the Dependencies of Core Layer")
- [Custom Exception Middleware](#custom-exception-middleware "Custom Exception Middleware")
	 - [Web Exception Middleware](#web-exception-middleware "Web Exception Middleware")
	 - [API Exception Middleware](#api-exception-middleware "API Exception Middleware")
- [Admin Panel UI Design](#admin-panel-ui-design "Admin Panel UI Design")	 
	 

### Connection String
When you have successfully downloaded the project, you must first change the Connection String. Connection String is defined in <code>AsminDbContext</code> under <code>Asmin.DataAccess.Concrete.EntityFramework.Context</code> namespace. (The project supports the Entity Framework. If you want, you can use another ORM. Independently ORM)

### Entity Layer Definitions

There are a few basic things to do when adding a new table to the database. First, a class belonging to the table must be created. This class is created under <code>Asmin.Entities.Concrete</code> and inherits through <code>BaseEntity</code> By the way created table must be defined in DbContext. (You know 💁)

```csharp
public class TEntity : BaseEntity
{
}
```

### Data Access Layer Definitions
A data access class is written for each database table created. The places where these definitions are made are <code>Asmin.DataAccess.Abstract</code> for the interface and <code>Asmin.DataAccess.Concrete</code> for concrete classes. Generic repository pattern is supported in this project. Below you can see the necessary implementations when creating a class.

<code>Asmin.DataAccess.Abstract</code>
```csharp
public interface ITEntityDal : IRepository<TEntity>
{
}

```
<code> Asmin.DataAccess.Concrete</code>
```csharp
public class TEntityDal : EfRepositoryBase<TEntity, TContext>, ITEntityDal
{
}
```
<code>TContext</code> is normally defined as <code>AsminDbContext</code>

### Business Layer Definitions
The manager classes of Entities corresponding to the database tables are written. This layer has more business codes. Validation operations, cache operations, authorization control, transaction  etc. Of course these are called from a central place.
The class definition of this layer is as follows.

<code>Asmin.Business.Abstract</code>
```csharp
public interface ITEntityManager
{
}
```
<code>Asmin.Business.Concrete</code>
```csharp
public class TEntityManager : ITEntityManager
{
}
```

#### Method Signature
When writing methods to the classes in the Business layer, we take care to comply with certain standards. In this project, the methods that send back data have the <code>IDataResult<></code> signature, while only those that perform operational operations have the <code>IResult</code> signature. There are two different results for these signatures, success and error states. You can find examples below.

```csharp
public IResult RemoveById(int id)
{
    //some code
    return new ErrorResult(ResultMessages.UserNotRemoved);
}
```
```csharp
public async IDataResult<int> GetCount()
{
    var count = // some code
    return new SuccessDataResult<int>(visitorsCount);
}
```
As you can see above, messages are not written directly for the produced results. Instead, we receive messages from the class called <code>ResultMessages</code> to provide control in one place.

### Defining the Dependencies of Business and Data Access Layer

In this project, transitions between layers, operational processes, service calls etc. is going to be abstracted. Of course, this is what is expected. We record the dependencies of these two layers (business and data access) through <code>Autofac</code>. We define dependencies in the <code>AutofacDependencyModule</code> class under <code>Asmin.Business.DependencyModules.Autofac</code> namespace. For example: 
```csharp
namespace Asmin.Business.DependencyModules.Autofac
{
    public class AutofacDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
                builder.RegisterType<TImplementation>().As<TInterface>();
        }
    }
}
```

#### Introducing Dependency Modules to the Web or API

After the dependencies are defined in <code>AutofacDependencyModule</code>, they need to be introduced to the system by Web or API. **This introductory process normally comes provided in this project**, but when a new Web or API project is added in the future, you can quickly define it with this documentation.

<code>Program.cs</code>
```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
```
<code>Startup.cs</code>
```csharp
public void ConfigureContainer(ContainerBuilder builder)
{
    builder.RegisterModule(new AutofacDependencyModule());
}
```

If you want to see other methods of adding dependencies, you can check the [Autofac](https://autofaccn.readthedocs.io/en/latest/configuration/modules.html "Autofac") documentation.

### Entity Validation Rules
We use the <code>Fluent Validation</code> library when validating objects in the project. We perform the definition of the rules under <code>Asmin.Business.ValidationRules.FluentValidation</code> namespace. You can find the rule definitions of a basic entity below.

```csharp
public class TEntityValidator : AbstractValidator<TEntity>
{
      public TEntityValidator()
      {
          RuleFor(entity => entity.Id).NotEmpty();
          RuleFor(entity => entity.Name).NotEmpty();
      }
}
```
After the class is written for the rules, it must be define into <code>AutofacDependencyModule</code> for used with dependency injection. You can review the documentation to learn about [Fluent Validation](https://fluentvalidation.net/ "Fluent Validation") and to see other definitions.

### Core Layer Definitions
In this layer, there are structures that will be used throughout the project. Specially the management of the structures we call Cross Cutting Concern, their writing as Aspect, services etc. 

#### Aspect Oriented Programming
We used the benefits of Aspect Oriented Programming in this project for readability and modularity of the code. There are some Aspects defined normally in this project. These;

##### Authorization Aspect
The Claims of the user sending the HTTP request are checked here. If the user has the desired claims, it continues. If not, the system is throwing an <code>AuthorizationException</code>. Don't worry, we are catching exception. 🤫😃

An example scenario;

```csharp
[AuthorizationAspect("IUserManager.AddAsync")]
public async Task<IResult> RemoveAsync(User user)
{
	await _userDal.RemoveAsnyc(user);
	return new SuccessResult(ResultMessages.UserRemoved);
}
```

If we look at the above definition, if there is no permission named <code>IUserManager.AddAsync</code> in Claimsler of the user who made the HTTP request, the process will not be able to continue. Here, a <code>method-based</code> process was carried out. If desired, a <code>role-based</code> structure can also be implemented.

##### Cache Aspect
Here, we cache the return value with a special key so as not to go to the database again. **The key value here is derived from the class and method name in which the method works. This will be very useful for us in the future.** 

An example scenario;

```csharp
[CacheAspect]
public async Task<IDataResult<List<User>>> GetListAsync()
{
	var users = await _userDal.GetListAsync();
	return new SuccessDataResult<List<User>>(users);
}
```

#####  Cache Remove Aspect

It may not match the memory value after deleting, updating, or doing some other operational action from the database. Here, too, we delete the data that matches the key we sent to Cache with the help of Regex.

```csharp
[CacheRemoveAspect("IUserManager.Get")]
public async Task<IResult> AddAsync(User user)
{
	await _userDal.AddAsnyc(user);
	return new SuccessResult(ResultMessages.UserAdded);
}
```

##### Unit Of Work Aspect
It is necessary to undo the operations made in the errors to be performed within the method.

An example scenario;

```csharp
[AsminUnitOfWorkAspect]
public void TransactionalTestMethod()
{
	User user1 = new User
	{
		FirstName = "Asmin",
		LastName = "Yılmaz",
		Email = "yusufyilmazfr@gmail.com",
		Password = "123"
	};

	User user2 = new User
	{
		Email = "yusufyilmazfr@gmail.com",
		Password = "123"
	};

	_userDal.Add(user1);
	_userDal.Add(user2);
}
```
Above, the first user object is an accurate description, but the second object is not correct. The registration will fail, so the first registration will be undone.

##### Exception Aspect
It is used to catch unexpected errors in the system. For example; no database connection, system settings mismatch etc.

An example scenario;

```csharp
[ExceptionAspect]
public async Task<IResult> UpdateAsync(User user)
{
	await _userDal.UpdateAsnyc(user);
	return new SuccessResult(ResultMessages.UserUpdated);
}
```

##### Log Aspect
It is useful to use it in Exception Aspect, in the analysis of unexpected errors etc. it will work. Or it can be used in desired places to provide security. It is completely up to business needs. It works with <code>Log4Net</code> in the background. It has the ability to record in two different locations, to the file and database. The requester's user receives the ip address, method information and parameters. This place can be changed optionally. If you want to see the details, you can go to <code>Asmin.Core.CrossCuttingConcerns.Logging namespace</code>

An example scenario;

```csharp
[LogAspect(typeof(FileLogger))]
public async Task<IResult> AddAsync(User user)
{
	await _userDal.AddAsnyc(user);
	return new SuccessResult(ResultMessages.UserAdded);
}
```

The path information of the file where the log records written is located in the <code>Log4Net.config</code> file. If you want change to path, go <code>Log4Net.config</code>

#### How Do  Write Custom Aspect

The Aspects described above may be insufficient according to your business needs or you may want to write something else. What you need to do here is derive the class you are creating from <code>MethodInterception</code>

For example:

```csharp
public class CustomAspect : MethodInterception
{
}
```

When deriving from <code>MethodInterceptor</code>, make sure <code>using Asmin.Core.Utilities.Interceptor</code> is written.

After defining the class, we can operate it at any time operationally. There are processes that can be override. These; <code>OnBefore</code>, <code>OnAfter</code>, <code>OnSuccess</code>, <code>OnException</code>, <code>Intercept</code>

After making the definition as above, you can use it as you wish. Simple, really. 🤗

#### Working Order of Aspects

Aspects normally work from top to bottom when written. In some cases, rows play a very important role for us. In such cases, we can determine the Aspects ourselves as shown below.

```csharp
[LogAspect(typeof(FileLogger), Priority = 2)]
[AuthorizationAspect("IUserManager.AddAsync", Priority = 1)]
[CacheRemoveAspect("IUserManager.Get", Priority = 3)]
public async Task<IResult> AddAsync(User user)
{
	await _userDal.AddAsnyc(user);
	return new SuccessResult(ResultMessages.UserAdded);
}
```
When we look at the code above, it works during <code>AuthorizationAspect</code>> <code>LogAspect</code>> <code>CacheRemoveAspect</code>

#### Cross Cutting Concerns 
##### Cache Service
<code>Microsoft Memory Cache</code> is default used in this project. If you want, Redis or another tool can be cached. **These transactions are abstracted in the project. (This is perfect! 😍)**  The only thing you need to do is to implement the <code>ICacheService</code> interface. These definitions are define under <code>Asmin.Core.CrossCuttingConcerns.Caching</code> namespace.

#### Hash Service
MD5 hash is default defined in <code>MD5HashService</code> class. However, another hash class can be defined if you want. **These transactions are abstracted in the project. (You know. 🥳)** The only thing you need to do is to implement the <code>IHashService</code> interface. These definitions are define under <code>Asmin.Core.Utilities.Hash</code> namespace.

For example:

```csharp
public class CustomHashService : IHashService
{
	public string CreateHash(string text)
	{
		//some code.
	}

	public bool Compare(string hashedText, string plainText)
	{
		//some code.
	}
}
```


#### Defining the Dependencies of Core Layer

The dependencies of the core layer are defined in <code>IServiceCollection</code>. We produce modules to make the dependency definitions here, then we make the definitions within the modules.
The module classes we have created implement the <code>ICoreModule</code> interface. Then, in the <code>Load (IServiceCollection services)</code> method, necessary dependency definitions are made.

Below is the MD5 hash service module that is defined as default in the system.

```csharp
public class MD5HashModule : ICoreModule
{
	public void Load(IServiceCollection services)
	{
		services.AddSingleton<IHashService, MD5HashService>();
	}
}
```
> We can also produce other similar modules, the same is true for Cache. If we use Redis Cache instead of the default Microsoft Memory Cache, a module is written for Redis Cache and definitions are made. In a possible change, only the module is replaced.
After making the definitions in the modules, it is necessary to define these modules on the Web or API side.

What we have to do here is quite simple. To introduce the modules with the help of the extension method we wrote in the <code>ConfigureServices</code> method in the <code>Startup</code> class.

in <code>Startup</code> class:

```csharp
public void ConfigureServices(IServiceCollection services)
{
	...
	services.AddDependencyModules(
		new ICoreModule[]
		{
			new MemoryCacheModule(),
			new MD5HashModule()
		});
	...
}
```
or
```csharp
public void ConfigureServices(IServiceCollection services)
{
	...
	services.AddDependencyModules();
	...
}
```

**Since Cache and Hash services are used by Business in the above definition, their modules are introduced. If you are not going to use them in projects, you can define empty parameter, but the method definition must be made even if it is empty. The reason is that system dependencies are used in the Core Layer.**


If you want to see the extension method written for <code>IServiceCollection</code>, you can look at the <code>ServiceCollectionExtensions</code> class under <code>Asmin.Core.Extensions</code> namespace

#### Custom Exception Middleware
It is not a nice behavior to give error messages directly to the user against the errors that will occur. That's why there are two middleware in the project, Web and API. 

##### Web Exception Middleware
The middleware for the Web will send to the error page defined by the user in a possible error.

For example:

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
	...
	app.UseMVCExceptionMiddleware("/Home/Exception");
	...
}
```

##### API Exception Middleware
The middleware written for the API will send the ExceptionMessage class back in case of errors. <code>ExceptionMessage</code>  class contains <code>StatusCode</code> and <code>Message</code>

For example:

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
	...
	app.UseAPIExceptionMiddleware();
	...
}
```
If you want, you can look at the details in the middleware. For this you should go to <code>Asmin.Core.Utilities.Middleware</code> namespace

#### Admin Panel UI Design

[SRTdash Admin Dashboard](https://github.com/puikinsh/srtdash-admin-dashboard "SRTdash Admin Dashboard") was used in the admin page designs. You can check the [GitHub](https://github.com/puikinsh/srtdash-admin-dashboard "GitHub") repository for documentation and other pages.



**Over time, this place will be further elaborated. ⌛⌛**

**We are very happy that you came here, I hope it was a useful and detailed document.  🥳🎉🎉**

**If you like or are using this project to learn or start your solution, please give it a ⭐️. Thanks!**
