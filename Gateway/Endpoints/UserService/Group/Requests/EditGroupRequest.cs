using Gateway.Data.Dtos;

namespace Gateway.Endpoints.UserService.Group.Requests;

public record EditGroupRequest(
    int Id,
    int SpecialityId,
    Guid CuratorId,
    byte CurrentCourse,
    byte CurrentSemester,
    byte SubGroup,
    bool IsDeleted,
    List<Guid>? Students
);
