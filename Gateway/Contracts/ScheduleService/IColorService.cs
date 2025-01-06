using Gateway.Data.Dtos.ScheduleService;
using Gateway.Endpoints.ScheduleService.Color.Requests;

namespace Gateway.Contracts.ScheduleService;

public interface IColorService
{
    Task<ColorDto> CreateColor(CreateColorRequest request);
}
