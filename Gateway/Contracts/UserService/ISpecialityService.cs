using Gateway.Data.Dtos;
using Gateway.Data.Enums;
using Gateway.Endpoints.UserService.Speciality.Enums;
using Gateway.Endpoints.UserService.Speciality.Requests;
using Gateway.Endpoints.UserService.Speciality.Responses;

namespace Gateway.Contracts.UserService;

public interface ISpecialityService
{
    public Task<SpecialityShortInfo> CreateSpeciality(CreateSpecialityRequest request);
    public Task<List<SpecialityShortInfo>> DeleteSpecialities(DeleteSpecialitiesRequest request);
    public Task<List<SpecialityShortInfo>> SoftDeleteSpecialities(
        DeleteSpecialitiesRequest request
    );
    public Task<List<SpecialityShortInfo>> RecoverySpecialities(
        RecoverySpecialitiesRequest request
    );
    public Task<SpecialityShortInfo> EditSpeciality(EditSpecialityRequest request);
    public Task<SpecialityDto> GetSpecialityById(int id);
    public Task<GetSpecialitiesResponse> GetSpecialities(
        int page,
        int pageSize,
        string? search,
        SpecialitySortState sortState,
        DeletedStatus deletedStatus
    );
}
