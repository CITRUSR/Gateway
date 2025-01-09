using Gateway.Data.Enums;
using Gateway.Endpoints.ScheduleService.Room.Enums;

namespace Gateway.Endpoints.ScheduleService.Room.Requests;

public record RoomFilter(string? SearchString, RoomFilterState FilterBy, OrderState OrderState);
