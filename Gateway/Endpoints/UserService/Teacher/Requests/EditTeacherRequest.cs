using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.UserService.Teacher.Requests;

public record EditTeacherRequest(
    [property: Required] Guid Id,
    [property: Required]
    [property: MaxLength(32)]
    [property: RegularExpression(@"\A\S+\z")]
        string FirstName,
    [property: Required]
    [property: MaxLength(32)]
    [property: RegularExpression(@"\A\S+\z")]
        string LastName,
    [property: MaxLength(32)] [property: RegularExpression(@"\A\S+\z")] string? PayronymicName,
    [property: Required] short RoomId,
    DateTime? FiredAt,
    [property: Required] bool IsDeleted
);
