using ScheduleServiceClient;

namespace Gateway.Data.Dtos.ScheduleService;

public record ClassDto(
    int Id,
    int GroupId,
    Subject Subject,
    Weekday Weekday,
    Color? Color,
    TimeSpan StartsAt,
    TimeSpan EndsAt,
    DateTime? ChangeOn,
    DateTime? IrrelevantSince,
    List<Guid> TeacherIds,
    List<Room> Rooms
);
