using Gateway.Data.Dtos.ScheduleService;
using Gateway.Endpoints.ScheduleService.Color.Requests;
using Gateway.Endpoints.ScheduleService.Color.Responses;

namespace Gateway.Contracts.ScheduleService;

public interface IColorService
{
    Task<ColorDto> CreateColorAsync(CreateColorRequest request);
    Task<ColorDto> GetColorByIdAsync(int id);
    Task<ColorDto> UpdateColorAsync(UpdateColorRequest request);
    Task<ColorDto> DeleteColorAsync(int id);
    Task<List<ColorViewModel>> GetColorsAsync();
}
