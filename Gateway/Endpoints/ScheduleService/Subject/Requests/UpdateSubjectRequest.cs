using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.ScheduleService.Subject.Requests;

public record UpdateSubjectRequest(
    [property: Required] int Id,
    [property: Required, MaxLength(128)] string Name,
    [property: MaxLength(10)] string? Abbreviation
);
