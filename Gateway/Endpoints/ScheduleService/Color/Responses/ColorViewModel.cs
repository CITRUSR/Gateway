using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.ScheduleService.Color.Responses;

public record ColorViewModel(
    [property: Required] int Id,
    [property: Required, MaxLength(10)] string Name
);
