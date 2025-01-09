using System.ComponentModel.DataAnnotations;

namespace Gateway.Data.Dtos.ScheduleService;

public record ColorDto(
    [property: Required] int Id,
    [property: Required, MaxLength(10)] string Name
);
