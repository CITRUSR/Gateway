using Gateway.Data.Dtos.ScheduleService;

namespace Gateway.Endpoints.ScheduleService.Class.Responses;

public record TeacherWeekdayColorClasses(WeekdayDto Weekday, List<TeacherColorClasses> Classes)
    : WeekdayColorClassesBase(Weekday);
