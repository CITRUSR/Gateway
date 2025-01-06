using System.ComponentModel.DataAnnotations;

namespace Gateway.Data.Dtos.ScheduleService;

public record RoomDto(
    [property: Required()] int Id,
    [property: Required(), MaxLength(10)] string Name,
    [property: MaxLength(128)] string? FullName
);
