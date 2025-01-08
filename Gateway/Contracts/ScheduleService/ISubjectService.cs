using Gateway.Data.Dtos.ScheduleService;
using Gateway.Endpoints.ScheduleService.Subject.Requests;

namespace Gateway.Contracts.ScheduleService;

public interface ISubjectService
{
    Task<SubjectDto> CreateSubject(CreateSubjectRequest request);
}
