namespace Gateway.Endpoints.UserService.Student.Requests;

public record DropOutStudentsRequest(List<Guid> StudentsId);
