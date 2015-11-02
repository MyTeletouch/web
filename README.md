# My Teletouch

## Wiki pages
  1. [DataModel.md](Wiki/DataModel.md)
  1. [SSL.md](Wiki/SSL.md)

### Table of Contents
  1. [Security](#security)
  1. [Internationalization](#internationalization)

### Security 

We will store all configuration in external files.

Our need to have `Security/AppSettingsSecrets.config`.

```xml
<appSettings> 

</appSettings>
```

### Sources:
  1. [Best practices for deploying passwords and other sensitive data to ASP.NET and Azure App Service](http://www.asp.net/identity/overview/features-api/best-practices-for-deploying-passwords-and-other-sensitive-data-to-aspnet-and-azure)
  
**[⬆ back to top](#table-of-contents)**

### Internationalization

### Sources:
  1. [ASP.NET MVC 5 Internationalization](http://afana.me/post/aspnet-mvc-internationalization.aspx)
   
**[⬆ back to top](#table-of-contents)**

### Migrations

```bash
enable-migrations -ContextProjectName MyTeletouch.DBContexts -contexttypename MyTeletouch.DBContexts.ApplicationDbContext -Verbose
```

### Sources:
  1. [Code First Migrations and Deployment with the Entity Framework in an ASP.NET MVC Application](http://www.asp.net/mvc/overview/getting-started/getting-started-with-ef-using-mvc/migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application)
  1. [Enable Migrations with Context in Separate Assembly?](https://stackoverflow.com/questions/18126711/enable-migrations-with-context-in-separate-assembly/18128768#18128768)