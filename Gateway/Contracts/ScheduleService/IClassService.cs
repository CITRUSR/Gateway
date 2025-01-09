using Gateway.Data.Dtos.ScheduleService;
using Gateway.Endpoints.ScheduleService.Class.Requests;

namespace Gateway.Contracts.ScheduleService;

public interface IClassService
{
    Task<ClassDto> CreateClass(CreateClassRequest request);
    Task<ClassDto> UpdateClass(UpdateClassRequest request);
    Task<ClassDto> GetClassById(int id);
    Task<ClassDto> DeleteClass(int id);
}
