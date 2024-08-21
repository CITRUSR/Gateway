using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.UserService.Student.Requests;

public record DeleteStudentsRequest([property: Required] List<Guid> StudentsId);
