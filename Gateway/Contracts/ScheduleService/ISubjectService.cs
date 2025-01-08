using Gateway.Data.Dtos.ScheduleService;
using Gateway.Endpoints.ScheduleService.Subject.Requests;
using Gateway.Endpoints.ScheduleService.Subject.Responses;

namespace Gateway.Contracts.ScheduleService;

public interface ISubjectService
{
    Task<SubjectDto> CreateSubject(CreateSubjectRequest request);
    Task<SubjectDto> GetSubjectById(int id);
    Task<SubjectDto> UpdateSubject(UpdateSubjectRequest request);
    Task<SubjectDto> DeleteSubject(int id);
    Task<GetSubjectsResponse> GetSubjects(GetSubjectsRequest request);
}
