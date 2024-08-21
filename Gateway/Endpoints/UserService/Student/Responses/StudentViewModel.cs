using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.UserService.Student.Responses;

public record StudentViewModel(
    [property: Required] Guid Id,
    [property: Required] [property: MaxLength(32)] string FirstName,
    [property: Required] [property: MaxLength(32)] string LastName,
    [property: MaxLength(32)] string? PatronymicName,
    [property: Required] string GroupName
);
