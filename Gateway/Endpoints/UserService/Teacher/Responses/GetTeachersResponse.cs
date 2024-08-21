using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.UserService.Teacher.Responses;

public record GetTeachersResponse(
    [property: Required] int LastPage,
    List<TeacherViewModel> Teachers
);
