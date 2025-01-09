namespace Gateway.Endpoints.ScheduleService.Class.Requests;

public record CreateClassRequest(
    int GroupId,
    int SubjectId,
    int WeekdayId,
    int? ColorId,
    TimeSpan StartsAt,
    TimeSpan EndsAt,
    DateTime? ChangeOn,
    List<Guid> TeachersIds,
    List<int> RoomIds
);
