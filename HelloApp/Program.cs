WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

// int x = 2;
// app.Run(async (context) =>
// {
//     x = x * 2;
//     await context.Response.WriteAsync("Result: " + x);
// });

// Setting Headers
// app.Run(async (context) =>
// {
//     var response = context.Response;
//     response.Headers.ContentLanguage = "ru-RU";
//     response.Headers.ContentType = "text/plain; charset=utf-8";
//     response.Headers.Append("secret-id", "256");
//     await response.WriteAsync("Привет мир!");
// });

// Setting status code
app.Run(async (context) =>
{
    context.Response.StatusCode = 404;
    await context.Response.WriteAsync("Resource not found!");
});

app.Run();