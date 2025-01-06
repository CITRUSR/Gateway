using Gateway.Contracts.ScheduleService;
using Gateway.Data.Dtos.ScheduleService;
using Gateway.Endpoints.ScheduleService.Color.Requests;
using Mapster;

namespace Gateway.Services.ScheduleService;

public class ColorService(ScheduleServiceClient.ColorService.ColorServiceClient client)
    : IColorService
{
    private readonly ScheduleServiceClient.ColorService.ColorServiceClient _client = client;

    public async Task<ColorDto> CreateColor(CreateColorRequest request)
    {
        var grpcRequest = request.Adapt<ScheduleServiceClient.CreateColorRequest>();

        var response = await _client.CreateColorAsync(grpcRequest);

        return response.Color.Adapt<ColorDto>();
    }
}
