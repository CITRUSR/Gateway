using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.UserService.Teacher.Responses;

public record TeacherShortInfo(
    [property: Required] Guid Id,
    [property: Required] [property: MaxLength(32)] string FirstName,
    [property: Required] [property: MaxLength(32)] string LastName
);
