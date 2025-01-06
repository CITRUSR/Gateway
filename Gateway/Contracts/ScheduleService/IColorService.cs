using Gateway.Data.Dtos.ScheduleService;
using Gateway.Endpoints.ScheduleService.Color.Requests;
using Gateway.Endpoints.ScheduleService.Color.Responses;

namespace Gateway.Contracts.ScheduleService;

public interface IColorService
{
    Task<ColorDto> CreateColor(CreateColorRequest request);
    Task<ColorDto> GetColorById(int id);
    Task<ColorDto> UpdateColor(UpdateColorRequest request);
    Task<ColorDto> DeleteColor(int id);
    Task<List<ColorViewModel>> GetColors();
}
