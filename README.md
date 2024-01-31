# Instructions

The focus of the exercise is on: connecting to an external database; defining models, relations and migrations; writing some basic tests and implementing DTOs. 


## Configure Json

Create a new appsettings.json / appsettings.Development.json (see appsettings.Example.json) add the following json and update credentials
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnectionString": "Host=HOST Database=DATABASE; Username=USERNAME; Password=PASSWORD; "
  }
}
```

## Install Nugets

- Install the following packages into the WebApi project:

- Install-Package Microsoft.EntityFrameworkCore
- Install-Package Microsoft.EntityFrameworkCore.Tools
- Install-Package Microsoft.EntityFrameworkCore.Design
- Install-Package NpgSql.EntityFrameworkCore.PostgreSql

## Install gitignore
```
dotnet new gitignore
```

Then add the following to the bottom of the file:

```
/workshop.wwwapi/appsettings.json
/workshop.wwwapi/appsettings.Development.json
*/**/bin/Debug   
*/**/bin/Release   
*/**/obj/Debug   
*/**/obj/Release   
```


## Migrations
- `Add-Migration MIGRATION_NAME`
- `Update-Database`


## Test Project

Examine the test project.  This is a a standard NUnit Test project (`dotnet new nunit --name workshop.tests`) with the additional package:

Install-Package Microsoft.Aspnecore.Mvc.Testing

Ensure that the following line is added to the bottom of the WebApi project:  
```
public partial class Program { } // needed for testing - please ignore
```
