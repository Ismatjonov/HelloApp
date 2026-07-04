WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run(HandleRequest);
app.Run();

// writing middleware in separated method
async Task HandleRequest(HttpContext context)
{
    await context.Response.WriteAsync("Hello Bakhtovar!!");
}