namespace Gateway.Endpoints.UserService.Teacher.Responses;

public record GetTeachersResponse(int LastPage, List<TeacherViewModel> Teachers);
