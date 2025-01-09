using Gateway.Data.Dtos.ScheduleService;

namespace Gateway.Endpoints.ScheduleService.Class.Responses;

public record GetClassesOnCurrentDateForTeacherResponse(
    WeekdayDto Weekday,
    ScheduleTeacherViewModel Teacher,
    List<TeacherColorClasses> Classes
);
