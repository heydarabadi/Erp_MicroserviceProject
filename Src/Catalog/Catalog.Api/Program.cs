using System.Reflection;
using Shared.Ui;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddUiSharedBuildServices(Assembly.GetExecutingAssembly());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
string projectName = "Catalog.Api";
app.UseUiSharedBuildServices(projectName);

app.Run();