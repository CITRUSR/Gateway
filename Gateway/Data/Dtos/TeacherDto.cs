using System.ComponentModel.DataAnnotations;

namespace Gateway.Data.Dtos;

public record TeacherDto
{
    Guid Id { get; set; }
    Guid SsoId { get; set; }

    [Required]
    [MaxLength(32)]
    string FirstName { get; set; }

    [Required]
    [MaxLength(32)]
    string LastName { get; set; }

    [MaxLength(32)]
    string? PatronymicName { get; set; }
    short RoomId { get; set; }
    DateTime? FiredAt { get; set; }
    bool IsDeleted { get; set; }
}
