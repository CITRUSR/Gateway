using Gateway.Data.Dtos.ScheduleService;

namespace Gateway.Endpoints.ScheduleService.Class.Responses;

public record GetClassesOnCurrentDateForStudentResponse(
    GroupViewModel Group,
    WeekdayDto Weekday,
    List<StudentColorClasses> Classes
);
