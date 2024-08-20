namespace Gateway.Endpoints.UserService.Group.Requests;

public record CreateGroupRequest(
    int SpecialityId,
    Guid CuratorId,
    byte CurrentCourse,
    byte CurrentSemester,
    byte SubGroup,
    DateTime StartedAt
);
