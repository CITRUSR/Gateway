namespace Gateway.Endpoints.UserService.Student.Responses;

public record GetStudentsResponse(int LastPage, List<StudentViewModel> Students);
