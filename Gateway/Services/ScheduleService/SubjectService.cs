using Gateway.Contracts.ScheduleService;
using Gateway.Data.Dtos.ScheduleService;
using Gateway.Endpoints.ScheduleService.Subject.Requests;
using Gateway.Endpoints.ScheduleService.Subject.Responses;
using Mapster;

namespace Gateway.Services.ScheduleService;

public class SubjectService(ScheduleServiceClient.SubjectService.SubjectServiceClient client)
    : ISubjectService
{
    private readonly ScheduleServiceClient.SubjectService.SubjectServiceClient _client = client;

    public async Task<SubjectDto> CreateSubjectAsync(CreateSubjectRequest request)
    {
        var grpcRequet = request.Adapt<ScheduleServiceClient.CreateSubjectRequest>();

        var result = await _client.CreateSubjectAsync(grpcRequet);

        return result.Subject.Adapt<SubjectDto>();
    }

    public async Task<SubjectDto> DeleteSubjectAsync(int id)
    {
        var grpcRequest = new ScheduleServiceClient.DeleteSubjectRequest() { Id = id };

        var result = await _client.DeleteSubjectAsync(grpcRequest);

        return result.Subject.Adapt<SubjectDto>();
    }

    public async Task<SubjectDto> GetSubjectById(int id)
    {
        var grpcRequest = new ScheduleServiceClient.GetSubjectByIdRequest { Id = id };

        var result = await _client.GetSubjectByIdAsync(grpcRequest);

        return result.Subject.Adapt<SubjectDto>();
    }

    public async Task<GetSubjectsResponse> GetSubjectsAsync(GetSubjectsRequest request)
    {
        var grpcRequest = request.Adapt<ScheduleServiceClient.GetSubjctsRequest>();

        var result = await _client.GetSubjctsAsync(grpcRequest);

        return result.Adapt<GetSubjectsResponse>();
    }

    public async Task<SubjectDto> UpdateSubjectAsync(UpdateSubjectRequest request)
    {
        var grpcRequest = request.Adapt<ScheduleServiceClient.UpdateSubjectRequest>();

        var result = await _client.UpdateSubjectAsync(grpcRequest);

        return result.Subject.Adapt<SubjectDto>();
    }
}
