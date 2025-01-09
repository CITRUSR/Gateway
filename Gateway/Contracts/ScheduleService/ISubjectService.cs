using Gateway.Data.Dtos.ScheduleService;
using Gateway.Endpoints.ScheduleService.Subject.Requests;
using Gateway.Endpoints.ScheduleService.Subject.Responses;

namespace Gateway.Contracts.ScheduleService;

public interface ISubjectService
{
    Task<SubjectDto> CreateSubjectAsync(CreateSubjectRequest request);
    Task<SubjectDto> GetSubjectById(int id);
    Task<SubjectDto> UpdateSubjectAsync(UpdateSubjectRequest request);
    Task<SubjectDto> DeleteSubjectAsync(int id);
    Task<GetSubjectsResponse> GetSubjectsAsync(GetSubjectsRequest request);
}
