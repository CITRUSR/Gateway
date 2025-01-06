using Gateway.Contracts.ScheduleService;
using Gateway.Data.Dtos.ScheduleService;
using Gateway.Endpoints.ScheduleService.Room.Requests;
using Mapster;

namespace Gateway.Services.ScheduleService;

public class RoomService(ScheduleServiceClient.RoomService.RoomServiceClient client) : IRoomService
{
    private readonly ScheduleServiceClient.RoomService.RoomServiceClient _client = client;

    public async Task<RoomDto> CreateRoom(CreateRoomRequest request)
    {
        var grpcRequest = request.Adapt<ScheduleServiceClient.CreateRoomRequest>();

        var response = await _client.CreateRoomAsync(grpcRequest);

        return response.Room.Adapt<RoomDto>();
    }
}
