using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.UserService.Teacher.Responses;

public record TeacherViewModel(
    [property: Required] Guid Id,
    [property: Required] [property: MaxLength(32)] string FirstName,
    [property: Required] [property: MaxLength(32)] string LastName,
    [property: MaxLength(32)] string? PatronymicName,
    string? GroupName,
    [property: Required] int RoomNumber
);
