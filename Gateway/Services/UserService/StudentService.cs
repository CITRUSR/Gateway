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

    public async Task<List<StudentShortInfo>> DropOutStudents(DropOutStudentsRequest request)
    {
        var grpcRequest = request.Adapt<UserServiceClient.DropOutStudentsRequest>();

        var result = await _studentService.DropOutStudentsAsync(grpcRequest);

        return result.Students.Adapt<List<StudentShortInfo>>();
    }

    public async Task<StudentShortInfo> EditStudent(EditStudentRequest request)
    {
        var grpcRequest = request.Adapt<UserServiceClient.EditStudentRequest>();

        var result = await _studentService.EditStudentAsync(grpcRequest);

        return result.Adapt<StudentShortInfo>();
    }

    public async Task<StudentDto> GetStudentById(Guid id)
    {
        var grpcRequest = new UserServiceClient.GetStudentByIdRequest { Id = id.ToString() };

        var result = await _studentService.GetStudentByIdAsync(grpcRequest);

        return result.Adapt<StudentDto>();
    }

    public async Task<StudentDto> GetStudentBySsoId(Guid ssoId)
    {
        var grpcRequest = new UserServiceClient.GetStudentBySsoIdRequest
        {
            SsoId = ssoId.ToString(),
        };

        var result = await _studentService.GetStudentBySsoIdAsync(grpcRequest);

        return result.Adapt<StudentDto>();
    }

    public async Task<GetStudentsResponse> GetStudents(
        int page,
        int pageSize,
        string? search,
        StudentSortState sortState,
        StudentDroppedOutStatus droppedOutStatus,
        DeletedStatus deletedStatus
    )
    {
        var grpcRequest = new UserServiceClient.GetStudentsRequest
        {
            Page = page,
            PageSize = pageSize,
            SearchString = search,
            DroppedOutStatus = (UserServiceClient.DroppedOutStatus)droppedOutStatus,
            SortState = (UserServiceClient.SortState)sortState,
            DeletedStatus = (UserServiceClient.DeletedStatus)deletedStatus,
        };

        var result = await _studentService.GetStudentsAsync(grpcRequest);

        return result.Adapt<GetStudentsResponse>();
    }

    public async Task<List<StudentViewModel>> GetStudentsByGroupId(int groupId)
    {
        var grpcRequest = new UserServiceClient.GetStudentsByGroupIdRequest { GroupId = groupId };

        var result = await _studentService.GetStudentsByGroupIdAsync(grpcRequest);

        return result.Students.Adapt<List<StudentViewModel>>();
    }

    public async Task<List<StudentShortInfo>> RecoveryStudents(RecoveryStudentsRequest request)
    {
        var grpcRequest = request.Adapt<UserServiceClient.RecoveryStudentsRequest>();

        var result = await _studentService.RecoveryStudentsAsync(grpcRequest);

        return result.Students.Adapt<List<StudentShortInfo>>();
    }

    public async Task<List<StudentShortInfo>> SoftDeleteStudents(DeleteStudentsRequest request)
    {
        var grpcRequest = request.Adapt<UserServiceClient.SoftDeleteStudentsRequest>();

        var result = await _studentService.SoftDeleteStudentsAsync(grpcRequest);

        return result.Students.Adapt<List<StudentShortInfo>>();
    }
}
