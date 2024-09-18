using System.Text.Json.Serialization;
using Gateway.Endpoints.UserService.Group;
using Gateway.Endpoints.UserService.Speciality;
using Gateway.Endpoints.UserService.Student;
using Gateway.Endpoints.UserService.Teacher;

namespace Gateway.Extensions;

public static class StartupExtensions
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
        services.Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
    }

    public static void ConfigureApplication(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
    }

    public static IApplicationBuilder MapEndpoints(this WebApplication app)
    {
        SpecialityEndpoints.Map(app);
        GroupEndpoints.Map(app);
        StudentEndpoints.Map(app);
        TeacherEndpoints.Map(app);

        return app;
    }
}
