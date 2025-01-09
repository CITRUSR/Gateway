using Gateway.Data.Dtos.ScheduleService;
using Gateway.Endpoints.ScheduleService.CurrentWeekday.Requests;

namespace Gateway.Contracts.ScheduleService;

public interface ICurrentWeekdayService
{
    Task<CurrentWeekdayDto> GetCurrentWeekdayAsync();
    Task<CurrentWeekdayDto> UpdateCurrentWeekdayAsync(UpdateCurrentWeekdayRequest request);
    Task<CurrentWeekdayDto> CreateCurrentWeekdayAsync(CreateCurrentWeekdayRequest request);
}
