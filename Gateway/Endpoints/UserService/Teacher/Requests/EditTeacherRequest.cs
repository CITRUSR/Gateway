using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.UserService.Teacher.Requests;

public record EditTeacherRequest(
    Guid Id,
    string FirstName,
    string LastName,
    string PayronymicName,
    short RoomId,
    DateTime? FiredAt,
    bool IsDeleted
);
