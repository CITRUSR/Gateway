namespace Gateway.Endpoints.UserService.Teacher.Responses;

public record TeacherViewModel(
    Guid Id,
    string FirstName,
    string LastName,
    string? PatronymicName,
    string? GroupName,
    int RoomNumber
);
