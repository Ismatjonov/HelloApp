using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
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
/*app.Run(async (context) =>
{
    var response = context.Response;
    var request = context.Request;
    if (request.HasJsonContentType())
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
});*/

// ----- Setting serialization -----
/*app.Run(async context =>
{
    var response = context.Response;
    var request = context.Request;
    if (request.Path == "/common.js")
    {
        response.ContentType = "application/javascript";
        await response.SendFileAsync("html/common.js");
    }
    else if (request.Path == "/api/user")
    {
        var responseText = "Incorrect data";

        if (request.HasJsonContentType())
        {
            var jsonOptions = new JsonSerializerOptions();
            jsonOptions.Converters.Add(new PersonConverter());
            var person = await request.ReadFromJsonAsync<Person>(jsonOptions);
            if (person != null)
                responseText = $"Name: {person.Name}, Age: {person.Age}";
        }

        await response.WriteAsJsonAsync(new { text = responseText });
    }
    else
    {
        response.ContentType = "text/html; charset=utf-8";
        await response.SendFileAsync("html/index.html");
    }
});*/


// =============== CREATING AN SIMPLE API ===============
/*List<Person> users = new List<Person> 
{ 
    new() { Id = Guid.NewGuid().ToString(), Name = "Tom", Age = 37 },
    new() { Id = Guid.NewGuid().ToString(), Name = "Bob", Age = 41 },
    new() { Id = Guid.NewGuid().ToString(), Name = "Sam", Age = 24 }
};*/
 
/*app.Run(async (context) =>
{
    var response = context.Response;
    var request = context.Request;
    var path = request.Path;
    //string expressionForNumber = "^/api/users/([0-9]+)$";   // если id представляет число
 
    // 2e752824-1657-4c7f-844b-6ec2e168e99c
    string expressionForGuid = @"^/api/users/\w{8}-\w{4}-\w{4}-\w{4}-\w{12}$";
    if (path == "/api/users" && request.Method=="GET")
    {
        await GetAllPeople(response); 
    }
    else if (Regex.IsMatch(path, expressionForGuid) && request.Method == "GET")
    {
        // получаем id из адреса url
        string? id = path.Value?.Split("/")[3];
        await GetPerson(id, response);
    }
    else if (path == "/api/users" && request.Method == "POST")
    {
        await CreatePerson(response, request);
    }
    else if (path == "/api/users" && request.Method == "PUT")
    {
        await UpdatePerson(response, request);
    }
    else if (Regex.IsMatch(path, expressionForGuid) && request.Method == "DELETE")
    {
        string? id = path.Value?.Split("/")[3];
        await DeletePerson(id, response);
    }
    else
    {
        response.ContentType = "text/html; charset=utf-8";
        await response.SendFileAsync("html/index.html");
    }
});*/



// ========== Uploading files to the server ==========
/*app.Run(async context =>
{
    var response = context.Response;
    var request = context.Request;
    
    response.ContentType = "text/html; charset=utf-8";

    if (request.Path == "/upload" && request.Method == "POST")
    {
        IFormFileCollection files = request.Form.Files;
        var uploadPath = $"{Directory.GetCurrentDirectory()}/upload";
        Directory.CreateDirectory(uploadPath);
        foreach(var file in files)
        {
            string fullPath = $"{uploadPath}/{file.FileName}";
            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
        }
        await response.WriteAsync("Files uploaded!");
    }
    else
    {
        await response.SendFileAsync("html/index.html");
    }
});*/

// ===================== Method Use() =====================
/*string date = "";
app.Use(async (context, next) =>
{
    Console.WriteLine($"Request: {context.Request.Path}");
    date = DateTime.Now.ToShortDateString();
    await next.Invoke();
    Console.WriteLine($"Current date: {date}");
});

app.Run(async context => await context.Response.WriteAsync($"Date: {date}"));

app.Run();*/

/*app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("<p>Hello World!</p>");
    await next.Invoke();
});

app.Run(async context =>
{
    await Task.Delay(5000);
    await context.Response.WriteAsync("<p>Good Bye, World...</p>");
});

app.Run();*/

/*app.Use(async (context, next) =>
{
    Console.WriteLine("First start");
    await next();
    Console.WriteLine("First end");
});
app.Use(async (context, next) =>
{
    Console.WriteLine("Second start");
    await next();
    Console.WriteLine("Second end");
});
app.Run(async context =>
{
    Console.WriteLine("Run");
});*/
 
// -------- Using delegate RequestDelegate -----
/*string date = "";

app.Use(async (context, next) =>
{
    date = DateTime.Now.ToShortDateString();    
    await next.Invoke(context);
    Console.WriteLine($"Current date: {date}");
});

app.Run(async context => await context.Response.WriteAsync($"Date: {date}"));

app.Run();*/

// ------ Terminal middleware component ------
/*app.Use(async (context, next) =>
{
    string? path = context.Request.Path.Value?.ToLower();
    if (path == "/date")
    {
        await context.Response.WriteAsync($"Date: {DateTime.Now.ToShortDateString()}");
    }
    else
    {
        await next.Invoke();
    }
});

app.Run(async context => await context.Response.WriteAsync("Hello World!"));

app.Run();*/

// ------ Use as a terminal middleware -----
/*app.Use(async (HttpContext context, Func<Task> next) =>
{
    await context.Response.WriteAsync("Hello World!");
});
app.Run();*/

// ------- Extracting components into methods --------
/*app.Use(GetDate);
app.Run(async context => await context.Response.WriteAsync("Hello World!"));
app.Run();
async Task GetDate(HttpContext context, Func<Task> next)
{
    string? path = context.Request.Path.Value?.ToLower();
    if (path == "/date")
    {
        await context.Response.WriteAsync($"Date: {DateTime.Now.ToShortDateString()}");
    }
    else
    {
        await next.Invoke();
    }
}*/


// ================ Creating a pipeline branch. UseWhen and MapWhen ================
app.UseWhen(
    context => context.Request.Path == "/time",
    appBuilder =>
    {
        appBuilder.Use(async (context, next) =>
        {
            var time = DateTime.Now.ToShortTimeString();
            Console.WriteLine($"Time: {time}");
            await next();
        });
        appBuilder.Run(async context =>
        {
            var time = DateTime.Now.ToShortTimeString();
            await context.Response.WriteAsync($"Time: {time}");
        });
    });
app.Run(async context => await context.Response.WriteAsync("Hello World!"));
app.Run();


// = = = = = = = = = = METHODS = = = = = = = = = =

/*// получение всех пользователей
async Task GetAllPeople(HttpResponse response)
{
    await response.WriteAsJsonAsync(users);
}
// получение одного пользователя по id
async Task GetPerson(string? id, HttpResponse response)
{
    // получаем пользователя по id
    Person? user = users.FirstOrDefault((u) => u.Id == id);
    // если пользователь найден, отправляем его
    if (user != null)
        await response.WriteAsJsonAsync(user);
    // если не найден, отправляем статусный код и сообщение об ошибке
    else
    {
        response.StatusCode = 404;
        await response.WriteAsJsonAsync(new { message = "Пользователь не найден" });
    }
}
 
async Task DeletePerson(string? id, HttpResponse response)
{
    // получаем пользователя по id
    Person? user = users.FirstOrDefault((u) => u.Id == id);
    // если пользователь найден, удаляем его
    if (user != null)
    {
        users.Remove(user);
        await response.WriteAsJsonAsync(user);
    }
    // если не найден, отправляем статусный код и сообщение об ошибке
    else
    {
        response.StatusCode = 404;
        await response.WriteAsJsonAsync(new { message = "Пользователь не найден" });
    }
}
 
async Task CreatePerson(HttpResponse response, HttpRequest request)
{
    try
    {
        // получаем данные пользователя
        var user = await request.ReadFromJsonAsync<Person>();
        if (user != null)
        {
            // устанавливаем id для нового пользователя
            user.Id = Guid.NewGuid().ToString();
            // добавляем пользователя в список
            users.Add(user);
            await response.WriteAsJsonAsync(user);
        }
        else
        {
            throw new Exception("Некорректные данные");
        }
    }
    catch (Exception)
    {
        response.StatusCode = 400;
        await response.WriteAsJsonAsync(new { message = "Некорректные данные" });
    }
}
 
async Task UpdatePerson(HttpResponse response, HttpRequest request)
{
    try
    {
        // получаем данные пользователя
        Person? userData = await request.ReadFromJsonAsync<Person>();
        if (userData != null)
        {
            // получаем пользователя по id
            var user = users.FirstOrDefault(u => u.Id == userData.Id);
            // если пользователь найден, изменяем его данные и отправляем обратно клиенту
            if (user != null)
            {
                user.Age = userData.Age;
                user.Name = userData.Name;
                await response.WriteAsJsonAsync(user);
            }
            else
            {
                response.StatusCode = 404;
                await response.WriteAsJsonAsync(new { message = "Пользователь не найден" });
            }
        }
        else
        {
            throw new Exception("Некорректные данные");
        }
    }
    catch (Exception)
    {
        response.StatusCode = 400;
        await response.WriteAsJsonAsync(new { message = "Некорректные данные" });
    }
}*/

// = = = = = = CLASSES = = = = = = 

public class Person
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

/*
 public class PersonConverter : JsonConverter<Person>
{
    public override Person Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var personName = "Undefined";
        var personAge = 0;
        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                var propertyName = reader.GetString();
                reader.Read();
                switch (propertyName?.ToLower())
                {
                    // if property age and contains int
                    case "age" when reader.TokenType == JsonTokenType.Number:
                        personAge = reader.GetInt32();  // reading number from JSON
                        break;
                    case "age" when reader.TokenType == JsonTokenType.String:
                        string? stringValue = reader.GetString();
                        // trying to convert string to number
                        if (int.TryParse(stringValue, out int value))
                        {
                            personAge = value;
                        }
                        break;
                    case "name":
                        string? name = reader.GetString();
                        if (name != null) personName = name;
                        break;
                }
            }
        }
        return new Person(personName, personAge);
    }

    public override void Write(Utf8JsonWriter writer, Person person, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("name", person.Name);
        writer.WriteNumber("age", person.Age);

        writer.WriteEndObject();
    }
}*/