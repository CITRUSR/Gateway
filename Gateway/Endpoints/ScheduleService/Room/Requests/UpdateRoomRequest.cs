using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.ScheduleService.Room.Requests;

public record UpdateRoomRequest(
    [property: Required()] int Id,
    [property: Required(), MaxLength(10)] string Name,
    [property: MaxLength(128)] string? FullName
);
