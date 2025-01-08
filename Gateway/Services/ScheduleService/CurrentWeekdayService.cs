using Gateway.Contracts.ScheduleService;

namespace Gateway.Services.ScheduleService;

public class CurrentWeekdayService(
    ScheduleServiceClient.CurrentWeekdayService.CurrentWeekdayServiceClient client
) : ICurrentWeekdayService
{
    private readonly ScheduleServiceClient.CurrentWeekdayService.CurrentWeekdayServiceClient _client =
        client;
}
