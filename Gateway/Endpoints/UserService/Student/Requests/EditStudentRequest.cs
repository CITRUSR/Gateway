using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.UserService.Student.Requests;

public record EditStudentRequest(
    [property: Required] Guid Id,
    [property: Required]
    [property: RegularExpression(@"\A\S+\z")]
    [property: MaxLength(32)]
        string FirstName,
    [property: Required]
    [property: RegularExpression(@"\A\S+\z")]
    [property: MaxLength(32)]
        string LastName,
    [property: RegularExpression(@"\A\S+\z")] [property: MaxLength(32)] string? PatronymicName,
    [property: Required] int GroupId,
    [property: Required] bool IsDeleted,
    DateTime? DroppedOutAt
);
