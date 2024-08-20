using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.UserService.Teacher.Requests;

public record EditTeacherRequest
{
    Guid Id { get; set; }

    [Required]
    [MaxLength(32)]
    string FirstName { get; set; }

    [Required]
    [MaxLength(32)]
    string LastName { get; set; }

    [MaxLength(32)]
    string PayronymicName { get; set; }
    short RoomId { get; set; }
    DateTime? FiredAt { get; set; }
    bool IsDeleted { get; set; }
}
