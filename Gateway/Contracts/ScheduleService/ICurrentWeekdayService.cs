using Gateway.Data.Dtos.ScheduleService;

namespace Gateway.Contracts.ScheduleService;

public interface ICurrentWeekdayService
{
    Task<CurrentWeekdayDto> GetCurrentWeekday();
}
