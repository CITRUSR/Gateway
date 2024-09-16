using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.UserService.Teacher.Requests;

public record RecoveryTeachersRequest([property: Required] List<Guid> TeachersId);
