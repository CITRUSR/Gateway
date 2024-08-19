namespace Gateway.Endpoints.UserService.Group.Responses;

public record GroupDetailInfo(
    int Id,
    int SpecialityId,
    Guid CuratorId,
    byte CurrentCourse,
    byte CurrentSemester,
    byte SubGroup,
    DateTime StartedAt,
    bool IsDeleted
);
