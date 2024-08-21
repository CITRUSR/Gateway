using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.UserService.Group.Requests;

public record CreateGroupRequest(
    [property: Required] int SpecialityId,
    [property: Required] Guid CuratorId,
    [property: Required] [property: Range(1, byte.MaxValue)] byte CurrentCourse,
    [property: Required] [property: Range(1, byte.MaxValue)] byte CurrentSemester,
    [property: Required] [property: Range(1, byte.MaxValue)] byte SubGroup,
    [property: Required] DateTime StartedAt
);
