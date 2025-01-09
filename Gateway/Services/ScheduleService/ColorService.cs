using Gateway.Contracts.ScheduleService;
using Gateway.Data.Dtos.ScheduleService;
using Gateway.Endpoints.ScheduleService.Color.Requests;
using Gateway.Endpoints.ScheduleService.Color.Responses;
using Mapster;

namespace Gateway.Services.ScheduleService;

public class ColorService(ScheduleServiceClient.ColorService.ColorServiceClient client)
    : IColorService
{
    private readonly ScheduleServiceClient.ColorService.ColorServiceClient _client = client;

    public async Task<ColorDto> CreateColorAsync(CreateColorRequest request)
    {
        var grpcRequest = request.Adapt<ScheduleServiceClient.CreateColorRequest>();

        var response = await _client.CreateColorAsync(grpcRequest);

        return response.Color.Adapt<ColorDto>();
    }

    public async Task<ColorDto> DeleteColorAsync(int id)
    {
        var grpcRequest = new ScheduleServiceClient.DeleteColorRequest() { Id = id };

        var result = await _client.DeleteColorAsync(grpcRequest);

        return result.Color.Adapt<ColorDto>();
    }

    public async Task<ColorDto> GetColorByIdAsync(int id)
    {
        var grpcRequest = new ScheduleServiceClient.GetColorByIdRequest() { Id = id };

        var response = await _client.GetColorByIdAsync(grpcRequest);

        return response.Color.Adapt<ColorDto>();
    }

    public async Task<List<ColorViewModel>> GetColorsAsync()
    {
        var grpcRequest = new ScheduleServiceClient.GetColorsRequest();

        var response = await _client.GetColorsAsync(grpcRequest);

        return response.Colors.Adapt<List<ColorViewModel>>();
    }

    public async Task<ColorDto> UpdateColorAsync(UpdateColorRequest request)
    {
        var grpcRequest = request.Adapt<ScheduleServiceClient.UpdateColorRequest>();

        var response = await _client.UpdateColorAsync(grpcRequest);

        return response.Color.Adapt<ColorDto>();
    }
}
