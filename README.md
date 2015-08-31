Hangfire.Funq
================



[Hangfire](http://hangfire.io) job activator based on [Funq](https://funq.codeplex.com/) IoC Container. 
Installation
--------------

HangFire.Funq is available as a NuGet Package. Type the following
command into NuGet Package Manager Console window to install it:

```
Install-Package Hangfire.Funq
```

Usage
------

In order to use the library, you should register it as your
JobActivator class:

```csharp
// Global.asax.cs or other file that initializes Funq bindings.
public partial class MyApplication : System.Web.HttpApplication
{
    private Funq.Container _container;

    protected void Application_Start()
    {
      _container = new Funq.Container();
      
      /* Register Types */
      _container.Register<Foo>(c => new Foo());
      
      GlobalConfiguration.Configuration.UseFunqActivator(_container);
    }
}
```
