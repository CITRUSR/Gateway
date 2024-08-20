using System.Text.Json.Serialization;
using Gateway.Endpoints.UserService.Group;
using Gateway.Endpoints.UserService.Speciality;
using Gateway.Endpoints.UserService.Student;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

SpecialityEndpoints.Map(app);
GroupEndpoints.Map(app);
StudentEndpoints.Map(app);

app.Run();
