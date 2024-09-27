using Gateway.Data.Dtos;
using Gateway.Data.Enums;
using Gateway.Endpoints.UserService.Student.Enums;
using Gateway.Endpoints.UserService.Student.Requests;
using Gateway.Endpoints.UserService.Student.Responses;

namespace Gateway.Contracts.UserService;

public interface IStudentService
{
    public Task<StudentShortInfo> CreateStudent(CreateStudentRequest request);
    public Task<List<StudentShortInfo>> DeleteStudents(DeleteStudentsRequest request);
    public Task<List<StudentShortInfo>> SoftDeleteStudents(DeleteStudentsRequest request);
    public Task<List<StudentShortInfo>> RecoveryStudents(RecoveryStudentsRequest request);
    public Task<List<StudentShortInfo>> DropOutStudents(DropOutStudentsRequest request);
    public Task<StudentShortInfo> EditStudent(EditStudentRequest request);
    public Task<StudentDto> GetStudentById(Guid id);
    public Task<StudentDto> GetStudentBySsoId(Guid ssoId);
    public Task<List<StudentViewModel>> GetStudentsByGroupId(int groupId);
    public Task<GetStudentsResponse> GetStudents(
        int page,
        int pageSize,
        string? search,
        StudentSortState sortState,
        StudentDroppedOutStatus droppedOutStatus,
        DeletedStatus deletedStatus
    );
}
