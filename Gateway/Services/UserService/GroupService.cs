using Gateway.Contracts.UserService;
using Gateway.Data.Dtos;
using Gateway.Data.Enums;
using Gateway.Endpoints.UserService.Group.Enums;
using Gateway.Endpoints.UserService.Group.Requests;
using Gateway.Endpoints.UserService.Group.Responses;
using Grpc.Net.Client;
using Mapster;

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

    public async Task<GroupShortInfo> CreateGroup(CreateGroupRequest request)
    {
        var grpcRequest = request.Adapt<UserServiceClient.CreateGroupRequest>();

        var result = await _groupService.CreateGroupAsync(grpcRequest);

        return result.Adapt<GroupShortInfo>();
    }

    public async Task<List<GroupShortInfo>> DeleteGroups(DeleteGroupsRequest request)
    {
        var grpcRequest = request.Adapt<UserServiceClient.DeleteGroupsRequest>();

        var result = await _groupService.DeleteGroupsAsync(grpcRequest);

        return result.Groups.Adapt<List<GroupShortInfo>>();
    }

    public async Task<GroupShortInfo> EditGroup(EditGroupRequest request)
    {
        var grpcRequest = request.Adapt<UserServiceClient.EditGroupRequest>();

        var result = await _groupService.EditGroupAsync(grpcRequest);

        return result.Adapt<GroupShortInfo>();
    }

    public async Task<GroupDto> GetGroupById(int id)
    {
        var grpcRequest = new UserServiceClient.GetGroupByIdRequest { Id = id };

        var result = await _groupService.GetGroupByIdAsync(grpcRequest);

        return result.Adapt<GroupDto>();
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
        var grpcRequest = new UserServiceClient.GetGroupsRequest
        {
            DeletedStatus = (UserServiceClient.DeletedStatus)deletedStatus,
            Page = page,
            PageSize = pageSize,
            SearchString = search,
            SortState = (UserServiceClient.GroupSortState)sortState,
            GraduatedStatus = (UserServiceClient.GroupGraduatedStatus)graduatedStatus,
        };

        var result = await _groupService.GetGroupsAsync(grpcRequest);

        return result.Adapt<GetGroupsResponse>();
    }

    public async Task<List<GroupShortInfo>> GraduateGroups(GraduateGroupsRequest request)
    {
        var grpcRequest = request.Adapt<UserServiceClient.GraduateGroupsRequest>();

        var result = await _groupService.GraduateGroupsAsync(grpcRequest);

        return result.Groups.Adapt<List<GroupShortInfo>>();
    }

    public async Task<List<GroupShortInfo>> RecoveryGroups(RecoveryGroupsRequest request)
    {
        var grpcReqeust = request.Adapt<UserServiceClient.RecoveryGroupsRequest>();

        var result = await _groupService.RecoveryGroupsAsync(grpcReqeust);

        return result.Groups.Adapt<List<GroupShortInfo>>();
    }

    public async Task<List<GroupShortInfo>> SoftDeleteGroups(DeleteGroupsRequest request)
    {
        var grpcRequest = request.Adapt<UserServiceClient.SoftDeleteGroupsRequest>();

        var result = await _groupService.SoftDeleteGroupsAsync(grpcRequest);

        return result.Groups.Adapt<List<GroupShortInfo>>();
    }

    public async Task<List<GroupShortInfo>> TransferGroupsToNextCourse(
        TransferGroupsToNextCourseRequest request
    )
    {
        var grpcRequest = request.Adapt<UserServiceClient.TransferGroupsToNextCourseRequest>();

        var result = await _groupService.TransferGroupsToNextCourseAsync(grpcRequest);

        return result.Groups.Adapt<List<GroupShortInfo>>();
    }

    public Task<List<GroupShortInfo>> TransferGroupsToNextSemester(
        TransferGroupsToNextSemesterRequest request
    )
    {
        throw new NotImplementedException();
    }
}
