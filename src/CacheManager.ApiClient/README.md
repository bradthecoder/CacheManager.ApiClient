# CacheManager.ApiClient

One Paragraph of project description goes here

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. 

### Prerequisites

This solution requires: 

- [Visual Studio 2019](https://visualstudio.microsoft.com/) (version 16.9 or higher)
- [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0)

### Installing

Add a reference to this new project to the head of your application.

Add the following code to the ConfigureServices method when initializing your application:

```csharp
// add using statement to Startup.cs
using CacheManager.ApiClient;


// add Dependency Injection to Startup.cs : ConfigureServices
services.AddCacheManagerApiClient();
```

Add an entry to your configuration files to access the Api Endpoint.

### Example appsettings.json

```json
{
  "EndpointUrl": {
    "CacheManagerApi": {
        "BaseUrl": "https://api.company.com"
    }
  }
}
```