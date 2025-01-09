using Gateway.Data.Dtos;
using Gateway.Data.Enums;
using Gateway.Endpoints.UserService.Student.Enums;
using Gateway.Endpoints.UserService.Student.Requests;
using Gateway.Endpoints.UserService.Student.Responses;

namespace Gateway.Contracts.UserService;

public interface IStudentService
{
    public Task<StudentShortInfo> CreateStudentAsync(CreateStudentRequest request);
    public Task<List<StudentShortInfo>> DeleteStudentsAsync(DeleteStudentsRequest request);
    public Task<List<StudentShortInfo>> SoftDeleteStudentsAsync(DeleteStudentsRequest request);
    public Task<List<StudentShortInfo>> RecoveryStudentsAsync(RecoveryStudentsRequest request);
    public Task<List<StudentShortInfo>> DropOutStudentsAsync(DropOutStudentsRequest request);
    public Task<StudentShortInfo> EditStudentAsync(EditStudentRequest request);
    public Task<StudentDto> GetStudentByIdAsync(Guid id);
    public Task<StudentDto> GetStudentBySsoIdAsync(Guid ssoId);
    public Task<List<StudentViewModel>> GetStudentsByGroupIdAsync(int groupId);
    public Task<GetStudentsResponse> GetStudentsAsync(
        int page,
        int pageSize,
        string? search,
        StudentSortState sortState,
        StudentDroppedOutStatus droppedOutStatus,
        DeletedStatus deletedStatus
    );
}
