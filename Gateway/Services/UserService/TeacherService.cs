using Gateway.Contracts.UserService;
using Gateway.Data.Dtos;
using Gateway.Data.Enums;
using Gateway.Endpoints.UserService.Teacher.Enums;
using Gateway.Endpoints.UserService.Teacher.Requests;
using Gateway.Endpoints.UserService.Teacher.Responses;
using Grpc.Net.Client;

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

    public Task<TeacherShortInfo> CreateTeacher(CreateTeacherRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<List<TeacherShortInfo>> DeleteTeachers(DeleteTeachersRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<TeacherShortInfo> EditTeacher(EditTeacherRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<List<TeacherShortInfo>> FireTeachers(FireTeachersRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<TeacherDto> GetTeacherById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<TeacherDto> GetTeacherBySsoId(Guid ssoId)
    {
        throw new NotImplementedException();
    }

    public Task<GetTeachersResponse> GetTeachers(
        int page,
        int pageSize,
        string? search,
        TeacherSortState sortState,
        DeletedStatus deletedStatus
    )
    {
        throw new NotImplementedException();
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
