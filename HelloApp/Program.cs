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
// app.Run(async (context) =>
// {
//     context.Response.StatusCode = 404;
//     await context.Response.WriteAsync("Resource not found!");
// });

/*app.Run(async (context) =>
{
    context.Response.Headers.ContentType = "text/html";
    await context.Response.WriteAsync("<h2>Hello World!</h2><h3>Welcome to ASP.NET Core</h3>");
});*/

// ========== HttpRequest. Getting request data ==========
/*app.Run(async(context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    var stringBuilder = new System.Text.StringBuilder("<table border='1' cellspacing='1' cellpadding='1'>");

    foreach (var header in context.Request.Headers)
    {
        stringBuilder.Append($"<tr><td>{header.Key}</td><td>{header.Value}</td></tr>");
    }
    stringBuilder.Append("</table>");
    await context.Response.WriteAsync(stringBuilder.ToString());
});*/

app.Run(async (context) =>
{
    var acceptHeaderValue = context.Request.Headers.Accept;
    await context.Response.WriteAsync($"Accept: {acceptHeaderValue}~");
});

app.Run();