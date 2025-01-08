using Gateway.Contracts.ScheduleService;

namespace Gateway.Services.ScheduleService;

public class SubjectService(ScheduleServiceClient.SubjectService.SubjectServiceClient client)
    : ISubjectService
{
    private readonly ScheduleServiceClient.SubjectService.SubjectServiceClient _client = client;
}
