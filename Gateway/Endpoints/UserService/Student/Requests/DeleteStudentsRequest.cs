namespace Gateway.Endpoints.UserService.Student.Requests;

public record DeleteStudentsRequest(List<Guid> StudentsId);
