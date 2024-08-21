using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.UserService.Teacher.Requests;

public record FireTeachersRequest([property: Required] List<Guid> TeachersId);
