using Gateway.Data.Dtos.ScheduleService;

namespace Gateway.Endpoints.ScheduleService.Class.Responses;

public record ClassDetailBase(
    int Id,
    int Order,
    SubjectDto Subject,
    TimeSpan StartsAt,
    TimeSpan EndsAt,
    DateTime? ChangeOn,
    List<RoomDto> Rooms
);
