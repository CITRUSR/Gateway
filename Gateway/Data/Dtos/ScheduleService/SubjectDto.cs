using System.ComponentModel.DataAnnotations;

namespace Gateway.Data.Dtos.ScheduleService;

public record SubjectDto(
    [property: Required()] int Id,
    [property: Required, MaxLength(128)] string Name,
    [property: MaxLength(10)] string? Abbreviation
);
