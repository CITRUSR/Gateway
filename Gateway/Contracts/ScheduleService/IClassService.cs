using Gateway.Data.Dtos.ScheduleService;
using Gateway.Endpoints.ScheduleService.Class.Requests;
using Gateway.Endpoints.ScheduleService.Class.Responses;

namespace Gateway.Contracts.ScheduleService;

public interface IClassService
{
    Task<ClassDto> CreateClassAsync(CreateClassRequest request);
    Task<ClassDto> UpdateClassAsync(UpdateClassRequest request);
    Task<ClassDto> GetClassByIdAsync(int id);
    Task<ClassDto> DeleteClassAsync(int id);
    Task<GetClassesOnCurrentDateForStudentResponse> GetClassesOnCurrentDateForStudentAsync(
        int GroupId
    );
    Task<GetClassesForWeekForStudentResponse> GetClassesForWeekForStudentAsync(int GroupId);
    Task<GetClassesOnCurrentDateForTeacherResponse> GetClassesOnCurrentDateForTeacherAsync(
        Guid TeacherId
    );
    Task<GetClassesForWeekForTeacherResponse> GetClassesForWeekForTeacherAsync(Guid teacherId);
}
