using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
//app.UseWelcomePage();

int count = 2;

app.Run(async (context) =>
{
    //count *= 2;
    //await context.Response.WriteAsync($"Result {count}");
    //var response = context.Response;
    //response.Headers.ContentLanguage = "ru-RU";
    //response.Headers.ContentType = "text/plain; charset=utf-8";
    //response.Headers.Append("my-secret-code", "max123");
    //response.StatusCode = 404;

    /*
    var request = context.Request;
    var strBuilder = new StringBuilder("<table>");

    foreach (var header in request.Headers)
        strBuilder.Append($"<tr><td>{header.Key}</td><td>{header.Value}</td></tr>");
    strBuilder.Append("</table>");

    context.Response.ContentType = "text/html";
    */

    
    var now = DateTime.Now;
    var request = context.Request;
    var response = context.Response;

    var path = request.Path;
    var queryString = request.QueryString;

    /*
    response.ContentType = "text/html";

    var strBuilder = new StringBuilder("<table>");
    strBuilder.Append("<tr><td>Key</td><td>Value</td></tr>");
    foreach (var query in request.Query)
        strBuilder.Append($"<tr><td>{query.Key}</td><td>{query.Value}</td></tr>");
    strBuilder.Append("</table>");

    await response.WriteAsync(strBuilder.ToString());
    */

    //await response.WriteAsync($"<p>Path: {path}</p><p>Query string: {queryString}</p>");


    /*
    if(path == "/date")
        await response.WriteAsync($"Date: {now.ToShortDateString()}");
    else if(path == "/time")
        await response.WriteAsync($"Date: {now.ToShortTimeString()}");
    else
        await context.Response.WriteAsync($"Welcome");
    */


    //await response.SendFileAsync(@"ada.jpg");
    //response.ContentType = "text/html";
    //await response.SendFileAsync("html/index.html");
    //response.Headers.ContentDisposition = "attachment; filename=ada_pict.jpg";
    //await response.SendFileAsync("ada.jpg");

    var fileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
    var fileInfo = fileProvider.GetFileInfo("ada.jpg");

    response.Headers.ContentDisposition = "attachment; filename=ada_pict.jpg";
    await response.SendFileAsync(fileInfo);
});

app.Run();
