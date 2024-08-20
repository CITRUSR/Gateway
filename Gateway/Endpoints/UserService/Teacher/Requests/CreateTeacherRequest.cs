namespace Gateway.Endpoints.UserService.Teacher.Requests;

public record CreateTeacherRequest(
    Guid SsoId,
    string FirstName,
    string LastName,
    string? PatronymicName,
    short RoomId
);
