using Gateway.Data.Common;

namespace Gateway.Endpoints.ScheduleService.Room.Requests;

public record GetRoomsRequest(RoomFilter Filter, PaginationParameters PaginationParameters);
