using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.UserService.Student.Responses;

public record GetStudentsResponse(
    [property: Required] int LastPage,
    List<StudentViewModel> Students
);
