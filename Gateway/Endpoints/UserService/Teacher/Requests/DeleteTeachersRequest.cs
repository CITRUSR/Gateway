using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.UserService.Teacher.Requests;

public record DeleteTeachersRequest([property: Required] List<Guid> TeachersId);
