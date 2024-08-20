using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.UserService.Teacher.Responses;

public record TeacherShortInfo
{
    Guid Id { get; set; }

    [Required]
    [MaxLength(32)]
    string FirstName { get; set; }

    [Required]
    [MaxLength(32)]
    string LastName { get; set; }
}
