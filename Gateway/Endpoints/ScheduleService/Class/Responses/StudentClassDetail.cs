using Gateway.Data.Dtos.ScheduleService;

namespace Gateway.Endpoints.ScheduleService.Class.Responses;

public record StudentClassDetail(
    int Id,
    int Order,
    SubjectDto Subject,
    TimeSpan StartsAt,
    TimeSpan EndsAt,
    DateTime? ChangeOn,
    List<RoomDto> Rooms,
    List<ScheduleTeacherViewModel> Teachers
) : ClassDetailBase(Id, Order, Subject, StartsAt, EndsAt, ChangeOn, Rooms);
