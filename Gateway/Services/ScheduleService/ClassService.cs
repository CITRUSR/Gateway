using Gateway.Contracts.ScheduleService;
using Gateway.Data.Dtos.ScheduleService;
using Gateway.Endpoints.ScheduleService.Class.Requests;
using Mapster;

namespace Gateway.Services.ScheduleService;

public class ClassService(ScheduleServiceClient.ClassService.ClassServiceClient client)
    : IClassService
{
    private readonly ScheduleServiceClient.ClassService.ClassServiceClient _client = client;

    public async Task<ClassDto> CreateClass(CreateClassRequest request)
    {
        var grpcRequest = request.Adapt<ScheduleServiceClient.CreateClassRequest>();

        var result = await _client.CreateClassAsync(grpcRequest);

        return result.Class.Adapt<ClassDto>();
    }
}
