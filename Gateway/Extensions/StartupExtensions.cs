using System.Text.Json.Serialization;
using Gateway.Contracts.ScheduleService;
using Gateway.Contracts.UserService;
using Gateway.Endpoints.ScheduleService.Class;
using Gateway.Endpoints.ScheduleService.Color;
using Gateway.Endpoints.ScheduleService.CurrentWeekday;
using Gateway.Endpoints.ScheduleService.Room;
using Gateway.Endpoints.ScheduleService.Subject;
using Gateway.Endpoints.UserService.Group;
using Gateway.Endpoints.UserService.Speciality;
using Gateway.Endpoints.UserService.Student;
using Gateway.Endpoints.UserService.Teacher;
using Gateway.Mappings;
using Gateway.Middlewares;
using Gateway.Services.ScheduleService;
using Gateway.Services.UserService;
using Google.Protobuf.Collections;
using Mapster;
using Serilog;

namespace Gateway.Extensions;

public static class StartupExtensions
{
    public static void ConfigureServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
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

        AddScheduleServiceGrpcClients(services, configuration);

        services.AddSingleton<ISpecialityService, SpecialityService>();
        services.AddSingleton<ITeacherService, TeacherService>();
        services.AddSingleton<IGroupService, GroupService>();
        services.AddSingleton<IStudentService, StudentService>();

        services.AddSingleton<IColorService, ColorService>();
        services.AddSingleton<IRoomService, RoomService>();
        services.AddSingleton<ISubjectService, SubjectService>();
        services.AddSingleton<ICurrentWeekdayService, CurrentWeekdayService>();
        services.AddSingleton<IClassService, ClassService>();
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

        ColorEndpoints.Map(app);
        RoomEndpoints.Map(app);
        SubjectEndpoints.Map(app);
        CurrentWeekdayEndpoints.Map(app);
        ClassEndpoints.Map(app);

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
        GroupConfig.Configure();
        StudentConfig.Configure();
        CurrentWeekdayConfig.Configure();
    }

    private static void AddScheduleServiceGrpcClients(
        IServiceCollection services,
        IConfiguration configuration
    )
    {
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator,
        };

        var serviceUrl = configuration.GetValue<string>("ServiceUrls:ScheduleService");

        services
            .AddGrpcClient<ScheduleServiceClient.ColorService.ColorServiceClient>(options =>
            {
                options.Address = new Uri(serviceUrl);
            })
            .ConfigurePrimaryHttpMessageHandler(() => handler);

        services
            .AddGrpcClient<ScheduleServiceClient.RoomService.RoomServiceClient>(options =>
            {
                options.Address = new Uri(serviceUrl);
            })
            .ConfigurePrimaryHttpMessageHandler(() => handler);

        services
            .AddGrpcClient<ScheduleServiceClient.SubjectService.SubjectServiceClient>(options =>
            {
                options.Address = new Uri(serviceUrl);
            })
            .ConfigurePrimaryHttpMessageHandler(() => handler);

        services
            .AddGrpcClient<ScheduleServiceClient.CurrentWeekdayService.CurrentWeekdayServiceClient>(
                options =>
                {
                    options.Address = new Uri(serviceUrl);
                }
            )
            .ConfigurePrimaryHttpMessageHandler(() => handler);

        services
            .AddGrpcClient<ScheduleServiceClient.ClassService.ClassServiceClient>(options =>
            {
                options.Address = new Uri(serviceUrl);
            })
            .ConfigurePrimaryHttpMessageHandler(() => handler);
    }
}
