using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.UserService.Student.Requests;

public record DropOutStudentsRequest(
    [property: Required] List<Guid> StudentsId,
    DateTime DroppedTime
);
