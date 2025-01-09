using Gateway.Contracts.ScheduleService;
using Gateway.Data.Dtos.ScheduleService;
using Gateway.Endpoints.ScheduleService.Class.Requests;
using Gateway.Endpoints.ScheduleService.Class.Responses;
using Mapster;

namespace Gateway.Services.ScheduleService;

public class ClassService(ScheduleServiceClient.ClassService.ClassServiceClient client)
    : IClassService
{
    private readonly ScheduleServiceClient.ClassService.ClassServiceClient _client = client;

    public async Task<ClassDto> CreateClassAsync(CreateClassRequest request)
    {
        var grpcRequest = request.Adapt<ScheduleServiceClient.CreateClassRequest>();

        var result = await _client.CreateClassAsync(grpcRequest);

        return result.Class.Adapt<ClassDto>();
    }

    public async Task<ClassDto> DeleteClassAsync(int id)
    {
        var grpcRequest = new ScheduleServiceClient.DeleteClassRequest { Id = id };

        var result = await _client.DeleteClassAsync(grpcRequest);

        return result.Class.Adapt<ClassDto>();
    }

    public async Task<ClassDto> GetClassByIdAsync(int id)
    {
        var grpcRequest = new ScheduleServiceClient.GetClassByIdRequest { Id = id };

        var result = await _client.GetClassByIdAsync(grpcRequest);

        return result.Class.Adapt<ClassDto>();
    }

    public async Task<GetClassesForWeekForStudentResponse> GetClassesForWeekForStudentAsync(
        int GroupId
    )
    {
        var grpcRequest = new ScheduleServiceClient.GetClassesForWeekForStudentRequest()
        {
            GroupId = GroupId,
        };

        var result = await _client.GetClassesForWeekForStudentAsync(grpcRequest);

        return result.Adapt<GetClassesForWeekForStudentResponse>();
    }

    public async Task<GetClassesForWeekForTeacherResponse> GetClassesForWeekForTeacherAsync(
        Guid teacherId
    )
    {
        var grpcRequest = new ScheduleServiceClient.GetClassesForWeekForTeacherRequest()
        {
            TeacherId = teacherId.ToString(),
        };

        var result = await _client.GetClassesForWeekForTeacherAsync(grpcRequest);

        return result.Adapt<GetClassesForWeekForTeacherResponse>();
    }

    public async Task<GetClassesOnCurrentDateForStudentResponse> GetClassesOnCurrentDateForStudentAsync(
        int GroupId
    )
    {
        var grpcRequest = new ScheduleServiceClient.GetClassesOnCurrentDateForStudentRequest()
        {
            GroupId = GroupId,
        };

        var result = await _client.GetClassesOnCurrentDateForStudentAsync(grpcRequest);

        return result.Adapt<GetClassesOnCurrentDateForStudentResponse>();
    }

    public async Task<GetClassesOnCurrentDateForTeacherResponse> GetClassesOnCurrentDateForTeacherAsync(
        Guid TeacherId
    )
    {
        var grpcRequest = new ScheduleServiceClient.GetClassesOnCurrentDateForTeacherRequest()
        {
            TeacherId = TeacherId.ToString(),
        };

        var result = await _client.GetClassesOnCurrentDateForTeacherAsync(grpcRequest);

        return result.Adapt<GetClassesOnCurrentDateForTeacherResponse>();
    }

    public async Task<ClassDto> UpdateClassAsync(UpdateClassRequest request)
    {
        var grpcRequest = request.Adapt<ScheduleServiceClient.UpdateClassRequest>();

        var result = await _client.UpdateClassAsync(grpcRequest);

        return result.Class.Adapt<ClassDto>();
    }
}
