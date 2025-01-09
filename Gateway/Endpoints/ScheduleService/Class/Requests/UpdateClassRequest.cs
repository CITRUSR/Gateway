using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.ScheduleService.Class.Requests;

public record UpdateClassRequest(
    [property: Required()] int ClassId,
    [property: Required()] int GroupId,
    [property: Required()] int SubjectId,
    [property: Required()] int WeekdayId,
    int? ColorId,
    [property: Required()] TimeSpan StartsAt,
    [property: Required()] TimeSpan EndsAt,
    DateTime? ChangeOn,
    [property: Required()] List<Guid> TeacherIds,
    [property: Required()] List<int> RoomIds
);
