using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.ScheduleService.Color.Requests;

public record CreateColorRequest([property: Required, MaxLength(10)] string Name);
