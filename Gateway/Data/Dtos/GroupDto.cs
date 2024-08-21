using System.ComponentModel.DataAnnotations;

namespace Gateway.Data.Dtos;

public record GroupDto(
    [property: Required] int Id,
    [property: Required] int SpecialityId,
    [property: Required] Guid CuratorId,
    [property: Required] [property: Range(1, byte.MaxValue)] byte CurrentCourse,
    [property: Required] [property: Range(1, byte.MaxValue)] byte CurrentSemester,
    [property: Required] [property: Range(1, byte.MaxValue)] byte SubGroup,
    [property: Required] DateTime StartedAt,
    DateTime? GraduatedAt,
    [property: Required] bool IsDeleted
);
