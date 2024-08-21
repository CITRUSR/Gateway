using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.UserService.Student.Requests;

public record CreateStudentRequest(
    [property: Required] Guid SsoId,
    [property: Required]
    [property: RegularExpression(@"\A\S+\z")]
    [property: MaxLength(32)]
        string FirstName,
    [property: Required]
    [property: RegularExpression(@"\A\S+\z")]
    [property: MaxLength(32)]
        string LastName,
    [property: RegularExpression(@"\A\S+\z")] [property: MaxLength(32)] string? PatronymicName,
    [Required] int GroupId
);
