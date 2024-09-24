using System.Text.Json.Serialization;
using Gateway.Contracts.UserService;
using Gateway.Endpoints.UserService.Group;
using Gateway.Endpoints.UserService.Speciality;
using Gateway.Endpoints.UserService.Student;
using Gateway.Endpoints.UserService.Teacher;
using Gateway.Mappings;
using Gateway.Middlewares;
using Gateway.Services.UserService;
using Google.Protobuf.Collections;
using Mapster;
using Serilog;

namespace Gateway.Extensions;

public static class StartupExtensions
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

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

        MapsterConfigure();

        services.AddSingleton<ISpecialityService, SpecialityService>();
        services.AddSingleton<ITeacherService, TeacherService>();
    }

    public static void ConfigureApplication(this WebApplication app)
    {
        app.UseMiddleware<GlobalExceptionHandler>();

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

    public static void MapsterConfigure()
    {
        TypeAdapterConfig.GlobalSettings.Default.UseDestinationValue(member =>
            member.SetterModifier == AccessModifier.None
            && member.Type.IsGenericType
            && member.Type.GetGenericTypeDefinition() == typeof(RepeatedField<>)
        );

        SpecialityConfig.Configure();
        TeacherConfig.Configure();
    }
}
