using Gateway.Contracts.UserService;
using Gateway.Data.Dtos;
using Gateway.Data.Enums;
using Gateway.Endpoints.UserService.Teacher.Enums;
using Gateway.Endpoints.UserService.Teacher.Requests;
using Gateway.Endpoints.UserService.Teacher.Responses;
using Grpc.Net.Client;
using Mapster;

namespace Gateway.Services.UserService;

public class TeacherService : ITeacherService
{
    private readonly UserServiceClient.TeacherService.TeacherServiceClient _teacherService;

    public TeacherService(IConfiguration configuration)
    {
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator,
        };

        var serviceUrl = configuration.GetValue<string>("ServiceUrls:UserService");

        var channel = GrpcChannel.ForAddress(
            serviceUrl,
            new GrpcChannelOptions { HttpClient = new HttpClient(handler) }
        );

        _teacherService = new UserServiceClient.TeacherService.TeacherServiceClient(channel);
    }

    public async Task<TeacherShortInfo> CreateTeacher(CreateTeacherRequest request)
    {
        var grpcRequest = request.Adapt<UserServiceClient.CreateTeacherRequest>();

        var result = await _teacherService.CreateTeacherAsync(grpcRequest);

        return result.Adapt<TeacherShortInfo>();
    }

    public async Task<List<TeacherShortInfo>> DeleteTeachers(DeleteTeachersRequest request)
    {
        var grpcRequest = request.Adapt<UserServiceClient.DeleteTeachersRequest>();

        var result = await _teacherService.DeleteTeachersAsync(grpcRequest);

        return result.Teachers.Adapt<List<TeacherShortInfo>>();
    }

    public async Task<TeacherShortInfo> EditTeacher(EditTeacherRequest request)
    {
        var grpcRequest = request.Adapt<UserServiceClient.EditTeacherRequest>();

        var result = await _teacherService.EditTeacherAsync(grpcRequest);

        return result.Adapt<TeacherShortInfo>();
    }

    public async Task<List<TeacherShortInfo>> FireTeachers(FireTeachersRequest request)
    {
        var grpcRequest = request.Adapt<UserServiceClient.FireTeachersRequest>();

        var result = await _teacherService.FireTeachersAsync(grpcRequest);

        return result.Teachers.Adapt<List<TeacherShortInfo>>();
    }

    public async Task<TeacherDto> GetTeacherById(Guid id)
    {
        var grpcRequest = new UserServiceClient.GetTeacherByIdRequest { Id = id.ToString() };

        var result = await _teacherService.GetTeacherByIdAsync(grpcRequest);

        return result.Adapt<TeacherDto>();
    }

    public async Task<TeacherDto> GetTeacherBySsoId(Guid ssoId)
    {
        var grpcRequest = new UserServiceClient.GetTeacherBySsoIdRequest
        {
            SsoId = ssoId.ToString(),
        };

        var result = await _teacherService.GetTeacherBySsoIdAsync(grpcRequest);

        return result.Adapt<TeacherDto>();
    }

    public async Task<GetTeachersResponse> GetTeachers(
        int page,
        int pageSize,
        string? search,
        TeacherSortState sortState,
        DeletedStatus deletedStatus
    )
    {
        var grpcRequest = new UserServiceClient.GetTeachersRequest
        {
            DeletedStatus = (UserServiceClient.DeletedStatus)deletedStatus,
            Page = page,
            PageSize = pageSize,
            SearchString = search,
            SortState = (UserServiceClient.TeacherSortState)sortState,
        };

        var result = await _teacherService.GetTeachersAsync(grpcRequest);

        return result.Adapt<GetTeachersResponse>();
    }

    public Task<List<TeacherShortInfo>> RecoveryTeachers(RecoveryTeachersRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<List<TeacherShortInfo>> SoftDeleteTeachers(DeleteTeachersRequest request)
    {
        throw new NotImplementedException();
    }
}
