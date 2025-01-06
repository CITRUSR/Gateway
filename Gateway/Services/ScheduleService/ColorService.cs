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

    public async Task<ColorDto> DeleteColor(int id)
    {
        var grpcRequest = new ScheduleServiceClient.DeleteColorRequest() { Id = id };

        var result = await _client.DeleteColorAsync(grpcRequest);

        return result.Color.Adapt<ColorDto>();
    }

    public async Task<ColorDto> GetColorById(int id)
    {
        var grpcRequest = new ScheduleServiceClient.GetColorByIdRequest() { Id = id };

        var response = await _client.GetColorByIdAsync(grpcRequest);

        return response.Color.Adapt<ColorDto>();
    }

    public async Task<ColorDto> UpdateColor(UpdateColorRequest request)
    {
        var grpcRequest = request.Adapt<ScheduleServiceClient.UpdateColorRequest>();

        var response = await _client.UpdateColorAsync(grpcRequest);

        return response.Color.Adapt<ColorDto>();
    }
}
