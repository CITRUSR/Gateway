using Gateway.Contracts.ScheduleService;
using Gateway.Data.Dtos.ScheduleService;
using Gateway.Endpoints.ScheduleService.CurrentWeekday.Requests;
using Mapster;

namespace Gateway.Services.ScheduleService;

public class CurrentWeekdayService(
    ScheduleServiceClient.CurrentWeekdayService.CurrentWeekdayServiceClient client
) : ICurrentWeekdayService
{
    private readonly ScheduleServiceClient.CurrentWeekdayService.CurrentWeekdayServiceClient _client =
        client;

    public async Task<CurrentWeekdayDto> CreateCurrentWeekdayAsync(
        CreateCurrentWeekdayRequest request
    )
    {
        var grpcRequest = request.Adapt<ScheduleServiceClient.CreateCurrentWeekdayRequest>();

        var result = await _client.CreateCurrentWeekdayAsync(grpcRequest);

        return result.CurrentWeekday.Adapt<CurrentWeekdayDto>();
    }

    public async Task<CurrentWeekdayDto> GetCurrentWeekdayAsync()
    {
        var grpcRequest = new ScheduleServiceClient.GetCurrentWeekdayRequest();

        var result = await _client.GetCurrentWeekdayAsync(grpcRequest);

        return result.CurrentWeekday.Adapt<CurrentWeekdayDto>();
    }

    public async Task<CurrentWeekdayDto> UpdateCurrentWeekdayAsync(
        UpdateCurrentWeekdayRequest request
    )
    {
        var grpcRequest = request.Adapt<ScheduleServiceClient.UpdateCurrentWeekdayRequest>();

        var result = await _client.UpdateCurrentWeekdayAsync(grpcRequest);

        return result.CurrentWeekday.Adapt<CurrentWeekdayDto>();
    }
}
