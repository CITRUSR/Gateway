namespace Gateway.Data.Dtos;

public record GroupDto(
    int Id,
    int SpecialityId,
    Guid CuratorId,
    byte CurrentCourse,
    byte CurrentSemester,
    byte SubGroup,
    DateTime StartedAt,
    DateTime? GraduatedAt,
    bool IsDeleted
);
