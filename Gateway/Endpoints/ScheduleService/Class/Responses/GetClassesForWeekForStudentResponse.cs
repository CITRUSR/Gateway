namespace Gateway.Endpoints.ScheduleService.Class.Responses;

public record GetClassesForWeekForStudentResponse(
    ScheduleGroupViewModel Group,
    List<StudentWeekdayColorClasses> Classes
);
