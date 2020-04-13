# .Net Core Training Course
.NET Core is a cross-platform, high-performance, [open-source](https://github.com/aspnet/home) framework for building modern, cloud-based, Internet-connected applications.
The purpose of this course is to give you the key concepts and topics to build .Net Core apps

## Summary

 - Fundamentals
	 - Overview
	 - CLI commands
	 - Startup Class
	 - Middleware
	 - Host
	 - Server
	 - Configuration
	 - Environments
	 - Logging
 -  Dependency Injection
	 - Fundamentals
	 - .Net Core DI
 - Data Layer
	 - ORM
	 - Patterns
	 - Entity Framework Core
 - Web Development
 - Security

# Fundamentals
**.NET Core** is a free and open-source managed computer software framework for the Windows, Linux, and macOS operating systems. It is an open source, cross platform successor of .NET Framework. The project is mainly developed by Microsoft and released under the MIT License.

## Download and Install
Please go to the official page from Microsoft and download the latest SDKavailable.
For this course we are going to work with .Net Core 2.2 Version downloaded form [MS Page](https://dotnet.microsoft.com/download).
Once you install the SDK, open a console window and type below comand to check the instalation:

    dotnet --info
You should see the information of the SDK installed as below image:
![dotnet info](assets/01_dotnetinfo.png?raw=true "dotnet --info")

If you want to know more about installation process you can see this [link](https://dotnet.microsoft.com/learn/dotnet/hello-world-tutorial/intro)

## CLI Commands

When you install the SDK, it provides a comand line interface(CLI), this inteface is a cross platform command line tool used for developing and performing various development activities when developing .Net Core applications.

### Command structure
CLI command structure consists of the **driver** ("dotnet"), the **command** (or "verb"), and possibly command **arguments** and **options**. You see this pattern in most CLI operations, such as creating a new console app and running it from the command line as the following commands show when executed from a directory named _my_app_:

    dotnet new console 
    dotnet build --output /build_output 
    dotnet /build_output/my_app.dll

### Driver
The driver is named  **dotnet** and has two responsibilities, either running a  **framework-dependent app** or executing a command.
To run a framework-dependent app, specify the app after the driver, for example,  `dotnet /path/to/my_app.dll`. When executing the command from the folder where the app's DLL resides, simply execute  `dotnet my_app.dll`.

### Command
The command (or "verb") is simply a command that performs an action. For example,  `dotnet build`  builds your code.  `dotnet publish`publishes your code. The commands are implemented as a console application using a  `dotnet {verb}`  convention.

### Arguments
The arguments you pass on the command line are the arguments to the command invoked. For example when you execute  `dotnet publish my_app.csproj`, the  `my_app.csproj`  argument indicates the project to publish and is passed to the  `publish`  command.

### Options
The options you pass on the command line are the options to the command invoked. For example when you execute  `dotnet publish --output /build_output`, the  `--output`  option and its value are passed to the  `publish`  command.

The following commands are installed with the SDK as default:

| Command |Description  |
|--|--|
|new|`dotnet new` - Creates a new project, configuration file, or solution based on the specified template.|
|restore|`dotnet restore` - Restores the dependencies and tools of a project.|
|build|`dotnet build` - Builds a project and all of its dependencies.|
|publish|`dotnet publish` - Packs the application and its dependencies into a folder for deployment to a hosting system.|
|run|`dotnet run` - Runs source code without any explicit compile or launch commands.|
|test|`dotnet test` - .NET test driver used to execute unit tests.|
|vstest|`dotnet-vstest` - Runs tests from the specified files.|
|pack|`dotnet pack` - Packs the code into a NuGet package.|
|migrate|`dotnet migrate` - Migrates a Preview 2 .NET Core project to a .NET Core SDK 1.0 project.|
|clean|`dotnet clean` - Cleans the output of a project.|
|sln|`dotnet sln` - Modifies a .NET Core solution file.|
|help|`dotnet help` - Shows more detailed documentation online for the specified command.|
|store|`dotnet store` - Stores the specified assemblies in the [runtime package store](https://docs.microsoft.com/en-us/dotnet/core/deploying/runtime-store).|
|add package|`dotnet add package` - Adds a package reference to a project file.|
|add reference|`dotnet add reference` - Adds project-to-project (P2P) references.|
|remove package|`dotnet remove package` - Removes package reference from a project file.|
|remove reference|`dotnet remove reference` - Removes project-to-project references.|
|list reference|`dotnet list reference` - Lists project-to-project references.|

TO know more about CLI you can see this [link](https://docs.microsoft.com/en-us/dotnet/core/tools/?tabs=netcore2x)

## Startup Class
Every project on .Net Core has a StartUp Class, who is an entry point where services required by the app are configured and the pipeline or middleware components are defined.

![Startup Class](assets/02_startup.png?raw=true "Startup class sample")

To know more about Startup Class you can go to this [link](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/startup?view=aspnetcore-2.2).

## Middleware

The request handling pipeline is composed as a series of middleware components. Each component performs asynchronous operations on an  `HttpContext`  and then either invokes the next middleware in the pipeline or terminates the request.

By convention, a middleware component is added to the pipeline by invoking its  `Use...`extension method in the  `Startup.Configure`  method. For example, to enable rendering of static files, call  `UseStaticFiles`.

![Middleware](assets/03_middlewarepipeline.png?raw=true "Http Pipeline")

To know more about Middleware you can go to this [link](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-2.2).

## Host

An ASP.NET Core app builds a  _host_  on startup. The host is an object that encapsulates all of the app's resources, such as:

-   An HTTP server implementation
-   Middleware components
-   Logging
-   DI
-   Configuration

The main reason for including all of the app's interdependent resources in one object is lifetime management: control over app startup and graceful shutdown.
Two hosts are available: the Web Host and the Generic Host. In ASP.NET Core 2.x, the Generic Host is only for non-web scenarios.

![WebHost](assets/04_webhost.png?raw=true "WebHost Sample configuration")

To know more about WebHost you can go to this [link](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/web-host?view=aspnetcore-2.2).

## Servers

An ASP.NET Core app uses an HTTP server implementation to listen for HTTP requests. The server surfaces requests to the app as a set of  [request features](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/request-features?view=aspnetcore-2.2)  composed into an  `HttpContext`.

ASP.NET Core provides the following server implementations:

-   _Kestrel_  is a cross-platform web server. Kestrel is often run in a reverse proxy configuration using  [IIS](https://www.iis.net/). In ASP.NET Core 2.0 or later, Kestrel can be run as a public-facing edge server exposed directly to the Internet.
-   _IIS HTTP Server_  is a server for windows that uses IIS. With this server, the ASP.NET Core app and IIS run in the same process.
-   _HTTP.sys_  is a server for Windows that isn't used with IIS.

To know more aout Servers you can go to this [link](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/index?view=aspnetcore-2.2&tabs=windows).

## Configuration

ASP.NET Core provides a configuration framework that gets settings as name-value pairs from an ordered set of configuration providers. There are built-in configuration providers for a variety of sources, such as  _.json_  files,  _.xml_  files, environment variables, and command-line arguments. You can also write custom configuration providers.

For example, you could specify that configuration comes from  _appsettings.json_  and environment variables. Then when the value of  _ConnectionString_  is requested, the framework looks first in the  _appsettings.json_  file. If the value is found there but also in an environment variable, the value from the environment variable would take precedence.

To know more about Configuration you can go to this [link](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-2.2).

## Environments

Execution environments, such as  _Development_,  _Staging_, and  _Production_, are a first-class notion in ASP.NET Core. You can specify the environment an app is running in by setting the  `ASPNETCORE_ENVIRONMENT`  environment variable. ASP.NET Core reads that environment variable at app startup and stores the value in an  `IHostingEnvironment`  implementation. The environment object is available anywhere in the app via Dependency Injection.

![Environments](assets/05_environments.png?raw=true "Environments Configuration")

To know more about Environments you can go to this [link](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/environments?view=aspnetcore-2.2).

## Logging

ASP.NET Core supports a logging API that works with a variety of built-in and third-party logging providers. Available providers include the following:

-   Console
-   Debug
-   Event Tracing on Windows
-   Windows Event Log
-   TraceSource
-   Azure App Service
-   Azure Application Insights

To know more about Logging you can go to this [link](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/index?view=aspnetcore-2.2).

# Dependency Injection
Is a technique whereby one object (or static method) supplies the dependencies of another object. A dependency is an object that can be used (a service). An injection is the passing of a dependency to a dependent object (a client) that would use it.

![DI](assets/06_dependencyinjection.png?raw=true "Dependency Injection")

To know more about DI you can see this links:
 - [.Net Core DI](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-2.2)
 - [IoC and DI Patterns - Martin Fowler](https://www.martinfowler.com/articles/injection.html)
 - [Visual Studio Toolbox](https://www.youtube.com/watch?v=QtDTfn8YxXg)

# Data Layer

## ORM
**Object-relational mapping** (**ORM**, **O/RM**, and **O/R mapping tool**) in computer science is a programming technique for converting data between incompatible type systems using object-oriented programming languages. This creates, in effect, a "virtual object database" that can be used from within the programming language. There are both free and commercial packages available that perform object-relational mapping, although some programmers opt to construct their own ORM tools.

![ORM](assets/07_orm.png?raw=true "ORM Structure")

## Entity Framework Core

EF Core can serve as an object-relational mapper (O/RM), enabling .NET developers to work with a database using .NET objects, and eliminating the need for most of the data-access code they usually need to write.

![EF](assets/08_efobjects.png?raw=true "Entity Framework Objects")