using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.ScheduleService.Subject.Requests;

public record CreateSubjectRequest(
    [property: Required, MaxLength(128)] string Name,
    [property: MaxLength(10)] string? Abbreviation
);
