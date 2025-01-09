using Gateway.Data.Dtos;
using Gateway.Data.Enums;
using Gateway.Endpoints.UserService.Teacher.Enums;
using Gateway.Endpoints.UserService.Teacher.Requests;
using Gateway.Endpoints.UserService.Teacher.Responses;

namespace Gateway.Contracts.UserService;

public interface ITeacherService
{
    public Task<TeacherShortInfo> CreateTeacherAsync(CreateTeacherRequest request);
    public Task<List<TeacherShortInfo>> DeleteTeachersAsync(DeleteTeachersRequest request);
    public Task<List<TeacherShortInfo>> SoftDeleteTeachersAsync(DeleteTeachersRequest request);
    public Task<List<TeacherShortInfo>> RecoveryTeachersAsync(RecoveryTeachersRequest request);
    public Task<List<TeacherShortInfo>> FireTeachersAsync(FireTeachersRequest request);
    public Task<TeacherShortInfo> EditTeacherAsync(EditTeacherRequest request);
    public Task<TeacherDto> GetTeacherByIdAsync(Guid id);
    public Task<TeacherDto> GetTeacherBySsoIdAsync(Guid ssoId);
    public Task<GetTeachersResponse> GetTeachersAsync(
        int page,
        int pageSize,
        string? search,
        TeacherSortState sortState,
        DeletedStatus deletedStatus
    );
}
