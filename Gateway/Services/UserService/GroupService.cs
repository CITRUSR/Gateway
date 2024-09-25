using Gateway.Contracts.UserService;
using Gateway.Data.Dtos;
using Gateway.Data.Enums;
using Gateway.Endpoints.UserService.Group.Enums;
using Gateway.Endpoints.UserService.Group.Requests;
using Gateway.Endpoints.UserService.Group.Responses;
using Grpc.Net.Client;

namespace Gateway.Services.UserService;

public class GroupService : IGroupService
{
    private readonly UserServiceClient.GroupService.GroupServiceClient _groupService;

    public GroupService(IConfiguration configuration)
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

        _groupService = new UserServiceClient.GroupService.GroupServiceClient(channel);
    }

    public Task<GroupShortInfo> CreateGroup(CreateGroupRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<List<GroupShortInfo>> DeleteGroups(DeleteGroupsRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<GroupShortInfo> EditGroup(EditGroupRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<GroupDto> GetGroupById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<GetGroupsResponse> GetGroups(
        int page,
        int pageSize,
        string? search,
        GroupSortState sortState,
        GroupGraduatedStatus graduatedStatus,
        DeletedStatus deletedStatus
    )
    {
        throw new NotImplementedException();
    }

    public Task<List<GroupShortInfo>> GraduateGroups(GraduateGroupsRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<List<GroupShortInfo>> RecoveryGroups(RecoveryGroupsRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<List<GroupShortInfo>> SoftDeleteGroups(DeleteGroupsRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<List<GroupShortInfo>> TransferGroupsToNextCourse(
        TransferGroupsToNextCourseRequest request
    )
    {
        throw new NotImplementedException();
    }

    public Task<List<GroupShortInfo>> TransferGroupsToNextSemester(
        TransferGroupsToNextSemesterRequest request
    )
    {
        throw new NotImplementedException();
    }
}
