using System.ComponentModel.DataAnnotations;

namespace Gateway.Data.Dtos;

public record StudentDto(
    [property: Required] Guid Id,
    [property: Required] Guid SsoId,
    [property: Required] [property: MaxLength(32)] string FirstName,
    [property: Required] [property: MaxLength(32)] string LastName,
    [property: MaxLength(32)] string? PatronymicName,
    [property: Required] int GroupId,
    DateTime? DroppedOutAt,
    [property: Required] bool IsDeleted
);
