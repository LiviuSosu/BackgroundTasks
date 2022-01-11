using Background_WindowsService;
//citeste aici https://docs.microsoft.com/en-us/dotnet/core/extensions/windows-service
IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
