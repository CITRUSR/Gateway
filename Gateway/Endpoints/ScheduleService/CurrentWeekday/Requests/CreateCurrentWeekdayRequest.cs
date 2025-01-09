using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.ScheduleService.CurrentWeekday.Requests;

public record CreateCurrentWeekdayRequest(
    [property: Required()] string Color,
    [property: Required()] TimeSpan Interval,
    [property: Required()] DateTime UpdateTime
);
