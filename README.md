# LogSnagSharp
A NuGet class library for LogSnag

<!-- ABOUT THE PROJECT -->
## About The Project
LogSnagSharp provides a NuGet class library "LogSnag" targeting .NET 5.0 for simple LogSnag integration into any C# project. This library handles the JSON encoding and transmitting of the POST requests required to send notifications to LogSnag in order to offload these responsibilities from the app developer.

## Installation
This package can be installed directly through Visual Studio's NuGet Package Manager or through the command line using the commands given on the [nuget.org package page](https://www.nuget.org/packages/LogSnag/).

<!-- USAGE EXAMPLES -->
## Usage
This package exposes a single class `LogSnag` which can be used to publish to a project. The project can either be set explicitly and reused with the `LogSnag(String, String)` constructor or with the `SetProject(String)` method used on an already constructed instance of `LogSnag`, or it can be explicitly provided to each publication using the `PublishToProject` method.

The `Publish` and `PublishToProject` methods provide optional parameters for full compatablity with the entire LogSnag API. Check the documentation at the [LogSnag Project](https://logsnag.com/) for full descriptions these optional parameters.

Example of using a single, explicitly set project for multiple publishes:
```cs
LogSnag client = new LogSnag("myAuthId", "my-project");
client.Publish("status-channel", "Service started");
// Perform service functions
if(failure)
{
    client.Publish("error-channel", $"Fatal error: {errorString}");
    client.Publish("status-channel", "Service stopped");
}
```

Example of using `PublishToProject` to publish to several projects:
```cs
LogSnag client = new LogSnag("myAuthId");
// Process requests for multiple services
client.PublishToProject(service.ProjectName, channelName);
```

Example of using `SetProject` to publish to different projects at different times:
```cs
LogSnag client = new LogSnag("myAuthId");
while(servicesRequested)
{
    if(requestedService == Services.SERVICE_ONE)
    {
        client.SetProject("service-one");
    }
    else
    {
        client.SetProject("service-two");
    }

    client.Publish("info", "User Logged In!");

    // Do processing
}
```

<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.

<!-- ACKNOWLEDGMENTS -->
## Acknowledgements

* Credit to othneildrew for this [README Template](https://github.com/othneildrew/Best-README-Template)
* [LogSnag Project](https://logsnag.com/)
* [NuGet Package Page](https://www.nuget.org/packages/LogSnag/)
