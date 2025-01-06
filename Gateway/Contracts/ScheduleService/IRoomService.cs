using Gateway.Data.Dtos.ScheduleService;
using Gateway.Endpoints.ScheduleService.Room.Requests;

namespace Gateway.Contracts.ScheduleService;

public interface IRoomService
{
    Task<RoomDto> CreateRoom(CreateRoomRequest request);
    Task<RoomDto> GetRoomById(int id);
}
