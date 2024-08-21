using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.UserService.Student.Responses;

public record StudentShortInfo(
    [property: Required] Guid Id,
    [property: Required] [property: MaxLength(32)] string FirstName,
    [property: Required] [property: MaxLength(32)] string LastName
);
