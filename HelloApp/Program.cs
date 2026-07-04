WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

await app.StartAsync();
await Task.Delay(10000);
await app.StopAsync();