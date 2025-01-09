using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.ScheduleService.CurrentWeekday.Requests;

public record UpdateCurrentWeekdayRequest(
    [property: Required()] string Color,
    [property: Required()] TimeSpan Interval,
    [property: Required()] DateTime UpdateTime
);
