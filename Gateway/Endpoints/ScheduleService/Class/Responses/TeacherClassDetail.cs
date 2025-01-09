using Gateway.Data.Dtos.ScheduleService;

namespace Gateway.Endpoints.ScheduleService.Class.Responses;

public record TeacherClassDetail(
    int Id,
    int Order,
    SubjectDto Subject,
    TimeSpan StartsAt,
    TimeSpan EndsAt,
    DateTime? ChangeOn,
    List<RoomDto> Rooms,
    ScheduleGroupViewModel Group
) : ClassDetailBase(Id, Order, Subject, StartsAt, EndsAt, ChangeOn, Rooms);
