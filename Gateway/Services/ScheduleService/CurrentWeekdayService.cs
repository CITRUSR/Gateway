using Gateway.Contracts.ScheduleService;
using Gateway.Data.Dtos.ScheduleService;
using Mapster;

namespace Gateway.Services.ScheduleService;

public class CurrentWeekdayService(
    ScheduleServiceClient.CurrentWeekdayService.CurrentWeekdayServiceClient client
) : ICurrentWeekdayService
{
    private readonly ScheduleServiceClient.CurrentWeekdayService.CurrentWeekdayServiceClient _client =
        client;

    public async Task<CurrentWeekdayDto> GetCurrentWeekday()
    {
        var grpcRequest = new ScheduleServiceClient.GetCurrentWeekdayRequest();

        var result = await _client.GetCurrentWeekdayAsync(grpcRequest);

        return result.CurrentWeekday.Adapt<CurrentWeekdayDto>();
    }
}
