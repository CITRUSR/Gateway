using System.ComponentModel.DataAnnotations;

namespace Gateway.Data.Dtos.ScheduleService;

public record WeekdayDto([property: Required()] int Id, [property: Required()] string Name);
