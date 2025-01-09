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
        ConfigureLogging();
        ConfigureSwagger(services);
        ConfigureJsonOptions(services);
        MapsterConfigure();
        RegisterServices(services);
        AddScheduleServiceGrpcClients(services, configuration);
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
        ClassConfig.Configure();
    }

    private static void ConfigureSwagger(IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    private static void ConfigureJsonOptions(IServiceCollection services)
    {
        services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
        services.Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
    }

    private static void RegisterServices(IServiceCollection services)
    {
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

    private static void ConfigureLogging()
    {
        Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
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

        if (string.IsNullOrEmpty(serviceUrl))
        {
            throw new InvalidOperationException(
                "Configuration value for 'ServiceUrls:ScheduleService' is missing or empty. "
                    + "Please ensure the configuration file contains this key."
            );
        }

        AddGrpcClient<ScheduleServiceClient.ColorService.ColorServiceClient>(
            services,
            serviceUrl,
            handler
        );

        AddGrpcClient<ScheduleServiceClient.RoomService.RoomServiceClient>(
            services,
            serviceUrl,
            handler
        );

        AddGrpcClient<ScheduleServiceClient.SubjectService.SubjectServiceClient>(
            services,
            serviceUrl,
            handler
        );

        AddGrpcClient<ScheduleServiceClient.CurrentWeekdayService.CurrentWeekdayServiceClient>(
            services,
            serviceUrl,
            handler
        );

        AddGrpcClient<ScheduleServiceClient.ClassService.ClassServiceClient>(
            services,
            serviceUrl,
            handler
        );
    }

    private static void AddGrpcClient<TClient>(
        IServiceCollection services,
        string serviceUrl,
        HttpClientHandler handler
    )
        where TClient : class
    {
        services
            .AddGrpcClient<TClient>(options =>
            {
                options.Address = new Uri(serviceUrl);
            })
            .ConfigurePrimaryHttpMessageHandler(() => handler);
    }
}
