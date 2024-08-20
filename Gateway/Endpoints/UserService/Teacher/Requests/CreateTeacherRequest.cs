using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.UserService.Teacher.Requests;

public record CreateTeacherRequest
{
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
}
