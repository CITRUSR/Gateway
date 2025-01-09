using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.ScheduleService.Class.Requests;

public record CreateClassRequest(
    [property: Required()] int GroupId,
    [property: Required()] int SubjectId,
    [property: Required()] int WeekdayId,
    int? ColorId,
    [property: Required()] TimeSpan StartsAt,
    [property: Required()] TimeSpan EndsAt,
    DateTime? ChangeOn,
    [property: Required()] List<Guid> TeachersIds,
    [property: Required()] List<int> RoomIds
);
