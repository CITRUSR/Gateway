using Gateway.Data.Dtos.ScheduleService;

namespace Gateway.Endpoints.ScheduleService.Class.Responses;

public record StudentWeekdayColorClasses(WeekdayDto Weekday, List<StudentColorClasses> Classes)
    : WeekdayColorClassesBase(Weekday);
