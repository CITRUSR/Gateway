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

    public async Task<ClassDto> GetClassById(int id)
    {
        var grpcRequest = new ScheduleServiceClient.GetClassByIdRequest { Id = id };

        var result = await _client.GetClassByIdAsync(grpcRequest);

        return result.Class.Adapt<ClassDto>();
    }

    public async Task<ClassDto> UpdateClass(UpdateClassRequest request)
    {
        var grpcRequest = request.Adapt<ScheduleServiceClient.UpdateClassRequest>();

        var result = await _client.UpdateClassAsync(grpcRequest);

        return result.Class.Adapt<ClassDto>();
    }
}
