namespace Gateway.Endpoints.UserService.Student.Requests;

public record EditStudentRequest(
    Guid Id,
    string FirstName,
    string LastName,
    string? PatronymicName,
    int GroupId,
    bool IsDeleted,
    DateTime? DroppedOutAt
);
