using Gateway.Data.Dtos.ScheduleService;
using Gateway.Endpoints.ScheduleService.Room.Requests;
using Gateway.Endpoints.ScheduleService.Room.Responses;

namespace Gateway.Contracts.ScheduleService;

public interface IRoomService
{
    Task<RoomDto> CreateRoom(CreateRoomRequest request);
    Task<RoomDto> GetRoomById(int id);
    Task<RoomDto> UpdateRoom(UpdateRoomRequest request);
    Task<RoomDto> DeleteRoom(int id);
    Task<GetRoomsResponse> GetRooms(GetRoomsRequest request);
}
