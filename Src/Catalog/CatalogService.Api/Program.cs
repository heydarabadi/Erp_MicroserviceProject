using System.Reflection;
using CatalogService.Api.ApplicationOptions;
using CatalogService.Api.Infrastructure.Db.MongoDb.DatabaseContexts;
using Microsoft.Extensions.Options;
using Shared.Infrastructure.OptionPatternConfiguration;
using Shared.Ui;

var builder = WebApplication.CreateBuilder(args);

#region Option Pattern
builder.Services.AddOptionsFromConfig<CatalogOptions>(builder.Configuration);
var serviceProvider = builder.Services.BuildServiceProvider();
var catalogOptions = serviceProvider.GetRequiredService<IOptions<CatalogOptions>>().Value;
#endregion
builder.Services.AddMongoDb(builder.Configuration, catalogOptions);
builder.Services.AddUiSharedBuildServices(Assembly.GetExecutingAssembly());
var app = builder.Build();

app.UseHttpsRedirection();

app.UseUiSharedBuildServices(builder.Configuration);

app.Run();