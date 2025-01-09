using Gateway.Data.Dtos.ScheduleService;
using Gateway.Endpoints.ScheduleService.Room.Requests;
using Gateway.Endpoints.ScheduleService.Room.Responses;

namespace Gateway.Contracts.ScheduleService;

public interface IRoomService
{
    Task<RoomDto> CreateRoomAsync(CreateRoomRequest request);
    Task<RoomDto> GetRoomByIdAsync(int id);
    Task<RoomDto> UpdateRoomAsync(UpdateRoomRequest request);
    Task<RoomDto> DeleteRoomAsync(int id);
    Task<GetRoomsResponse> GetRoomsAsync(GetRoomsRequest request);
}
