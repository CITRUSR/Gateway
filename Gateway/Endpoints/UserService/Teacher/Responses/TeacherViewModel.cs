using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.UserService.Teacher.Responses;

public record TeacherViewModel
{
    Guid Id { get; set; }

    [Required]
    [MaxLength(32)]
    string FirstName { get; set; }

    [Required]
    [MaxLength(32)]
    string LastName { get; set; }
    string? PatronymicName { get; set; }
    string? GroupName { get; set; }
    int RoomNumber { get; set; }
}
