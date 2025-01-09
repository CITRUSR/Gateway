using Gateway.Data.Dtos;
using Gateway.Data.Enums;
using Gateway.Endpoints.UserService.Group.Enums;
using Gateway.Endpoints.UserService.Group.Requests;
using Gateway.Endpoints.UserService.Group.Responses;

namespace Gateway.Contracts.UserService;

public interface IGroupService
{
    public Task<GroupShortInfo> CreateGroupAsync(CreateGroupRequest request);
    public Task<List<GroupShortInfo>> DeleteGroupsAsync(DeleteGroupsRequest request);
    public Task<List<GroupShortInfo>> SoftDeleteGroupsAsync(DeleteGroupsRequest request);
    public Task<List<GroupShortInfo>> RecoveryGroupsAsync(RecoveryGroupsRequest request);
    public Task<GroupShortInfo> EditGroupAsync(EditGroupRequest request);
    public Task<List<GroupShortInfo>> GraduateGroupsAsync(GraduateGroupsRequest request);
    public Task<List<GroupShortInfo>> TransferGroupsToNextSemesterAsync(
        TransferGroupsToNextSemesterRequest request
    );
    public Task<List<GroupShortInfo>> TransferGroupsToNextCourseAsync(
        TransferGroupsToNextCourseRequest request
    );
    public Task<GroupDto> GetGroupByIdAsync(int id);
    public Task<GetGroupsResponse> GetGroupsAsync(
        int page,
        int pageSize,
        string? search,
        GroupSortState sortState,
        GroupGraduatedStatus graduatedStatus,
        DeletedStatus deletedStatus
    );
}
