using Gateway.Contracts.UserService;
using Gateway.Data.Dtos;
using Gateway.Data.Enums;
using Gateway.Endpoints.UserService.Student.Enums;
using Gateway.Endpoints.UserService.Student.Requests;
using Gateway.Endpoints.UserService.Student.Responses;
using Grpc.Net.Client;
using Mapster;

namespace Gateway.Services.UserService;

public class StudentService : IStudentService
{
    private readonly UserServiceClient.StudentService.StudentServiceClient _studentService;

    public StudentService(IConfiguration configuration)
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

        _studentService = new UserServiceClient.StudentService.StudentServiceClient(channel);
    }

    public async Task<StudentShortInfo> CreateStudent(CreateStudentRequest request)
    {
        var grpcRequest = request.Adapt<UserServiceClient.CreateStudentRequest>();

        var result = await _studentService.CreateStudentAsync(grpcRequest);

        return result.Adapt<StudentShortInfo>();
    }

    public async Task<List<StudentShortInfo>> DeleteStudents(DeleteStudentsRequest request)
    {
        var grpcRequest = request.Adapt<UserServiceClient.DeleteStudentsRequest>();

        var result = await _studentService.DeleteStudentsAsync(grpcRequest);

        return result.Students.Adapt<List<StudentShortInfo>>();
    }

    public Task<List<StudentShortInfo>> DropOutStudents(DropOutStudentsRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<StudentShortInfo> EditStudent(EditStudentRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<StudentDto> GetStudentById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<StudentDto> GetStudentBySsoId(Guid ssoId)
    {
        throw new NotImplementedException();
    }

    public Task<GetStudentsResponse> GetStudents(
        int page,
        int pageSize,
        string? search,
        StudentSortState sortState,
        StudentDroppedOutStatus droppedOutStatus,
        DeletedStatus deletedStatus
    )
    {
        throw new NotImplementedException();
    }

    public Task<List<StudentViewModel>> GetStudentsByGroupId(int groupId)
    {
        throw new NotImplementedException();
    }

    public Task<List<StudentShortInfo>> RecoveryStudents(RecoveryStudentsRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<List<StudentShortInfo>> SoftDeleteStudents(DeleteStudentsRequest request)
    {
        throw new NotImplementedException();
    }
}
