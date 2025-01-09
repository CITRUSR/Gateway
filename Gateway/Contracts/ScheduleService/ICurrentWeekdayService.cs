using Gateway.Data.Dtos.ScheduleService;
using Gateway.Endpoints.ScheduleService.CurrentWeekday.Requests;

namespace Gateway.Contracts.ScheduleService;

public interface ICurrentWeekdayService
{
    Task<CurrentWeekdayDto> GetCurrentWeekday();
    Task<CurrentWeekdayDto> UpdateCurrentWeekday(UpdateCurrentWeekdayRequest request);
}
