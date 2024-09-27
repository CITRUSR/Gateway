using Gateway.Data.Dtos;
using Gateway.Data.Enums;
using Gateway.Endpoints.UserService.Teacher.Enums;
using Gateway.Endpoints.UserService.Teacher.Requests;
using Gateway.Endpoints.UserService.Teacher.Responses;

namespace Gateway.Contracts.UserService;

public interface ITeacherService
{
    public Task<TeacherShortInfo> CreateTeacher(CreateTeacherRequest request);
    public Task<List<TeacherShortInfo>> DeleteTeachers(DeleteTeachersRequest request);
    public Task<List<TeacherShortInfo>> SoftDeleteTeachers(DeleteTeachersRequest request);
    public Task<List<TeacherShortInfo>> RecoveryTeachers(RecoveryTeachersRequest request);
    public Task<List<TeacherShortInfo>> FireTeachers(FireTeachersRequest request);
    public Task<TeacherShortInfo> EditTeacher(EditTeacherRequest request);
    public Task<TeacherDto> GetTeacherById(Guid id);
    public Task<TeacherDto> GetTeacherBySsoId(Guid ssoId);
    public Task<GetTeachersResponse> GetTeachers(
        int page,
        int pageSize,
        string? search,
        TeacherSortState sortState,
        DeletedStatus deletedStatus
    );
}
