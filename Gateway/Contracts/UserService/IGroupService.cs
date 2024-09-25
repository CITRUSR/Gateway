using Gateway.Data.Dtos;
using Gateway.Data.Enums;
using Gateway.Endpoints.UserService.Group.Enums;
using Gateway.Endpoints.UserService.Group.Requests;
using Gateway.Endpoints.UserService.Group.Responses;

namespace Gateway.Contracts.UserService;

public interface IGroupService
{
    public Task<GroupShortInfo> CreateGroup(CreateGroupRequest request);
    public Task<List<GroupShortInfo>> DeleteGroups(DeleteGroupsRequest request);
    public Task<List<GroupShortInfo>> SoftDeleteGroups(DeleteGroupsRequest request);
    public Task<List<GroupShortInfo>> RecoveryGroups(RecoveryGroupsRequest request);
    public Task<GroupShortInfo> EditGroup(EditGroupRequest request);
    public Task<List<GroupShortInfo>> GraduateGroups(GraduateGroupsRequest request);
    public Task<List<GroupShortInfo>> TransferGroupsToNextSemester(
        TransferGroupsToNextSemesterRequest request
    );
    public Task<List<GroupShortInfo>> TransferGroupsToNextCourse(
        TransferGroupsToNextCourseRequest request
    );
    public Task<GroupDto> GetGroupById(int id);
    public Task<GetGroupsResponse> GetGroups(
        int page,
        int pageSize,
        string? search,
        GroupSortState sortState,
        GroupGraduatedStatus graduatedStatus,
        DeletedStatus deletedStatus
    );
}
