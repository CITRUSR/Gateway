namespace Gateway.Endpoints.UserService.Student.Requests;

public record CreateStudentRequest(
    Guid SsoId,
    string FirstName,
    string LastName,
    string? PatronymicName,
    int GroupId
);
