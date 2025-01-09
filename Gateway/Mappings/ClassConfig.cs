using Gateway.Data.Dtos.ScheduleService;
using Gateway.Endpoints.ScheduleService.Class.Requests;
using Gateway.Endpoints.ScheduleService.Class.Responses;
using Google.Protobuf.WellKnownTypes;
using Mapster;

namespace Gateway.Mappings;

public static class ClassConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<ScheduleServiceClient.Class, ClassDto>
            .NewConfig()
            .Map(dest => dest.StartsAt, src => src.StartsAt.ToTimeSpan())
            .Map(dest => dest.EndsAt, src => src.EndsAt.ToTimeSpan())
            .Map(
                dest => dest.ChangeOn,
                src => src.ChangeOn == null ? (DateTime?)null : DateTime.Parse(src.ChangeOn)
            )
            .Map(
                dest => dest.IrrelevantSince,
                src =>
                    src.IrrelevantSince == null
                        ? (DateTime?)null
                        : DateTime.Parse(src.IrrelevantSince)
            );

        TypeAdapterConfig<CreateClassRequest, ScheduleServiceClient.CreateClassRequest>
            .NewConfig()
            .Map(dest => dest.StartsAt, src => src.StartsAt.ToDuration())
            .Map(dest => dest.EndsAt, src => src.EndsAt.ToDuration())
            .Map(
                dest => dest.ChangeOn,
                src => src.ChangeOn == null ? null : src.ChangeOn.ToString()
            )
            .Map(dest => dest.TeacherIds, src => src.TeachersIds);

        TypeAdapterConfig<UpdateClassRequest, ScheduleServiceClient.UpdateClassRequest>
            .NewConfig()
            .Map(dest => dest.StartsAt, src => src.StartsAt.ToDuration())
            .Map(dest => dest.EndsAt, src => src.EndsAt.ToDuration())
            .Map(
                dest => dest.ChangeOn,
                src => src.ChangeOn == null ? null : src.ChangeOn.ToString()
            )
            .Map(dest => dest.TeacherIds, src => src.TeacherIds);

        TypeAdapterConfig<
            ScheduleServiceClient.GetClassesOnCurrentDateForStudentResponse,
            GetClassesOnCurrentDateForStudentResponse
        >
            .NewConfig()
            .Map(dest => dest.Group, src => src.Group.Adapt<ScheduleGroupViewModel>())
            .Map(dest => dest.Weekday, src => src.Weekday.Adapt<WeekdayDto>())
            .Map(dest => dest.Classes, src => src.Classes.Adapt<List<StudentColorClasses>>());

        TypeAdapterConfig<ScheduleServiceClient.StudentColorClasses, StudentColorClasses>
            .NewConfig()
            .Map(dest => dest.Color, src => src.Color.Adapt<ColorDto>())
            .Map(dest => dest.Classes, src => src.Classes.Adapt<List<StudentClassDetail>>());

        TypeAdapterConfig<ScheduleServiceClient.StudentClassDetail, StudentClassDetail>
            .NewConfig()
            .Map(dest => dest.Subject, src => src.Subject.Adapt<SubjectDto>())
            .Map(dest => dest.StartsAt, src => src.StartsAt.ToTimeSpan())
            .Map(dest => dest.EndsAt, src => src.EndsAt.ToTimeSpan())
            .Map(dest => dest.Rooms, src => src.Rooms.Adapt<List<RoomDto>>())
            .Map(
                dest => dest.Teachers,
                src => src.Teachers.Adapt<List<ScheduleTeacherViewModel>>()
            );

        TypeAdapterConfig<
            ScheduleServiceClient.StudentWeekdayColorClassesDto,
            StudentWeekdayColorClasses
        >
            .NewConfig()
            .Map(dest => dest.Weekday, src => src.Weekday.Adapt<WeekdayDto>())
            .Map(dest => dest.Classes, src => src.Classes.Adapt<List<StudentColorClasses>>());

        TypeAdapterConfig<
            ScheduleServiceClient.GetClassesForWeekForStudentResponse,
            GetClassesForWeekForStudentResponse
        >
            .NewConfig()
            .Map(
                dest => dest.Classes,
                src => src.Classes.Adapt<List<StudentWeekdayColorClasses>>()
            );

        TypeAdapterConfig<
            ScheduleServiceClient.GetClassesOnCurrentDateForTeacherResponse,
            GetClassesOnCurrentDateForTeacherResponse
        >
            .NewConfig()
            .Map(dest => dest.Teacher, src => src.Teacher.Adapt<ScheduleTeacherViewModel>())
            .Map(dest => dest.Weekday, src => src.Weekday.Adapt<WeekdayDto>())
            .Map(dest => dest.Classes, src => src.Classes.Adapt<List<TeacherColorClasses>>());

        TypeAdapterConfig<ScheduleServiceClient.TeacherColorClasses, TeacherColorClasses>
            .NewConfig()
            .Map(dest => dest.Color, src => src.Color.Adapt<ColorDto>())
            .Map(dest => dest.Classes, src => src.Classes.Adapt<List<TeacherClassDetail>>());

        TypeAdapterConfig<ScheduleServiceClient.TeacherClassDetail, TeacherClassDetail>
            .NewConfig()
            .Map(dest => dest.StartsAt, src => src.StartsAt.ToTimeSpan())
            .Map(dest => dest.EndsAt, src => src.EndsAt.ToTimeSpan());

        TypeAdapterConfig<
            ScheduleServiceClient.GetClassesForWeekForTeacherResponse,
            GetClassesForWeekForTeacherResponse
        >
            .NewConfig()
            .Map(dest => dest.Teacher, src => src.Teacher.Adapt<ScheduleTeacherViewModel>())
            .Map(
                dest => dest.Classes,
                src => src.Classes.Adapt<List<TeacherWeekdayColorClasses>>()
            );
    }
}
