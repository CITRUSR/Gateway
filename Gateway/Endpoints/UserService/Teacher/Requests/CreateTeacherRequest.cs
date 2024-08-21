using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.UserService.Teacher.Requests;

public record CreateTeacherRequest(
    [property: Required] Guid SsoId,
    [property: Required]
    [property: MaxLength(32)]
    [property: RegularExpression(@"\A\S+\z")]
        string FirstName,
    [property: Required]
    [property: MaxLength(32)]
    [property: RegularExpression(@"\A\S+\z")]
        string LastName,
    [property: MaxLength(32)] [property: RegularExpression(@"\A\S+\z")] string? PatronymicName,
    [property: Required] short RoomId
);
