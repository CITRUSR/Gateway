using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.ScheduleService.Color.Requests;

public record UpdateColorRequest(
    [property: Required] int Id,
    [property: Required, MaxLength(10)] string Name
);
