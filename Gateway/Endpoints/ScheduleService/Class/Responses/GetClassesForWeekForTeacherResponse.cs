namespace Gateway.Endpoints.ScheduleService.Class.Responses;

public record GetClassesForWeekForTeacherResponse(
    ScheduleTeacherViewModel Teacher,
    List<TeacherWeekdayColorClasses> Classes
);
