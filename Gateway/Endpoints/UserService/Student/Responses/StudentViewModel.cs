namespace Gateway.Endpoints.UserService.Student.Responses;

public record StudentViewModel(
    Guid Id,
    string FirstName,
    string LastName,
    string PatronymicName,
    string GroupName
);
