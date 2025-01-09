namespace Gateway.Data.Dtos.ScheduleService;

public record CurrentWeekdayDto(int Id, string Color, TimeSpan Interval, DateTime? UpdatedAt);
