using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.UserService.Student.Requests;

public record RecoveryStudentsRequest([property: Required] List<Guid> StudentsId);
