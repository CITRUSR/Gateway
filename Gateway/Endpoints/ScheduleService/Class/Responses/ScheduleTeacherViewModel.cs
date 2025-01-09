using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.ScheduleService.Class.Responses;

public record ScheduleTeacherViewModel(
    [property: Required()] Guid Id,
    [property: Required()] string FirstName,
    [property: Required()] string LastName,
    string? PatronymicName
);
