using Microsoft.Extensions.FileProviders;

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

/*app.Run(async (context) =>
{
    var acceptHeaderValue = context.Request.Headers.Accept;
    await context.Response.WriteAsync($"Accept: {acceptHeaderValue}");
});*/

// ---- Getting a path of request ----
// app.Run(async context => await context.Response.WriteAsync($"Path: {context.Request.Path}"));

/*app.Run(async (context) =>
{
    var path = context.Request.Path;
    var now = DateTime.Now;
    var response = context.Response;
    
    if(path == "/date")
        await response.WriteAsync(now.ToShortDateString());
    else if (path == "/time")
        await response.WriteAsync(now.ToLongTimeString());
    else
        await response.WriteAsync("Hello METANIT.COM");
});*/

// ---- Query string ----
/*app.Run(async context =>
{
    context.Response.ContentType = "text/html charset=utf-8";
    await context.Response.WriteAsync($"<p>Path: {context.Request.Path}</p>" +
                                      $"<p>QueryString: {context.Request.QueryString}</p>");
});*/

// params of query string
/*app.Run(async context =>
{
    context.Response.ContentType = "text/html charset=utf-8";
    var stringBuilder = new System.Text.StringBuilder("<h3>Parameters of Query String</h3><table border='1'>");
    stringBuilder.Append("<tr><td>Parameter</td><td>Value</td></tr>");
    foreach (var param in context.Request.Query)
    {
        stringBuilder.Append($"<tr><td>{param.Key}</td><td>{param.Value}</td></tr>");
    }
    stringBuilder.Append("</table>");
    await context.Response.WriteAsync(stringBuilder.ToString());
});*/

/*app.Run(async context =>
{
    string name = context.Request.Query["name"];
    string age = context.Request.Query["age"];
    await context.Response.WriteAsync($"{name} - {age}");
});*/


// ========== Sending files ==========

/*app.Run(async context =>
{
    await context.Response.SendFileAsync("cat.jpg");
});*/

// ---- sending html-files ----
/*app.Run(async context =>
{
    context.Response.ContentType = "text/html charset=utf-8";
    await context.Response.SendFileAsync("html/index.html");
});*/

// ---- complex tasks ----
/*app.Run(async context =>
{
    var path = context.Request.Path;
    var fullPath = $"html/{path}";
    var response = context.Response;
    
    response.ContentType = "text/html charset=utf-8";
    if (File.Exists(fullPath))
    {
        response.SendFileAsync(fullPath);
    }
    else
    {
        response.StatusCode = 404;
        await response.WriteAsync("<h2>Not Found!</h2>");
    }
});*/

// ---- Downloading files -----
/*app.Run(async context =>
{
    context.Response.Headers.ContentDisposition = "attachment; filename=my_cat.jpg";
    await context.Response.SendFileAsync("cat.jpg");
});*/

// ----- IFileInfo -----
/*app.Run(async context =>
{
    var fileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
    var fileInfo = fileProvider.GetFileInfo("cat.jpg");
    
    context.Response.Headers.ContentDisposition = "attachment; filename=cat2.jpg";
    await context.Response.SendFileAsync(fileInfo);
});*/


// ========== Sending forms ==========
/*app.Run(async context =>
{
    context.Response.ContentType = "text/html charset=utf-8";

    if (context.Request.Path == "/postuser")
    {
        var form = context.Request.Form;
        string name = form["name"];
        int age = int.Parse(form["age"]);
        await context.Response.WriteAsync($"<div><p>Name: {name}</p><p>Age: {age}</p></div>");
    }
    else
    {
        await context.Response.SendFileAsync("html/index.html");
    }
});*/

// ----- Getting arrays -----
/*app.Run(async context =>
{
    context.Response.ContentType = "text/html charset=utf-8";

    if (context.Request.Path == "/postuser")
    {
        string name = context.Request.Form["name"];
        string age = context.Request.Form["age"];
        string[] languages = context.Request.Form["languages"];
        // creating a string from arrray
        string langList = "";
        foreach (string lang in languages)
        {
            langList += $" {lang}";
        }

        await context.Response.WriteAsync($"<div><p>Name: {name}</p></div>" +
                                          $"<p>Age: {age}</p>" +
                                          $"<p>Languages: {langList}</p>");
    }
    else
    {
        await context.Response.SendFileAsync("html/index.html");
    }
});*/


// ==================== Redirect ====================
/*app.Run(async context =>
{
    if (context.Request.Path == "/old")
    {
        context.Response.Redirect("https://www.google.com/search?q=metanit.com");
    }
    else if (context.Request.Path == "/new")
    {
        await context.Response.WriteAsync("New Page");
    }
    else
    {
        await context.Response.WriteAsync("Main Page");
    }
});*/


// ==================== Getting and Setting JSON ====================

// ---- sending JSON ---- 
/*app.Run(async context =>
{
    Person person = new("Tom", 22);
    await context.Response.WriteAsJsonAsync(person);
});*/

// ---- getting JSON -----
app.Run(async (context) =>
{
    var response = context.Response;
    var request = context.Request;
    if (request.Path == "/api/user")
    {
        var message = "Некорректные данные";   // default content
        try
        {
            // trying to het get json data
            var person = await request.ReadFromJsonAsync<Person>();
            if (person != null) // if data converted to the JSON
                message = $"Name: {person.Name},  Age: {person.Age}";
        }
        catch { }
        // sending data to user
        await response.WriteAsJsonAsync(new { text = message });
    }
    else
    {
        response.ContentType = "text/html; charset=utf-8";
        await response.SendFileAsync("html/index.html");
    }
});

app.Run();

public record class Person(string Name, int Age);