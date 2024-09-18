using Gateway.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices();

var app = builder.Build();

app.ConfigureApplication();
app.MapEndpoints();

app.Run();
