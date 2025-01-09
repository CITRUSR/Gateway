using Gateway.Data.Dtos;
using Gateway.Data.Enums;
using Gateway.Endpoints.UserService.Speciality.Enums;
using Gateway.Endpoints.UserService.Speciality.Requests;
using Gateway.Endpoints.UserService.Speciality.Responses;

namespace Gateway.Contracts.UserService;

public interface ISpecialityService
{
    public Task<SpecialityShortInfo> CreateSpecialityAsync(CreateSpecialityRequest request);
    public Task<List<SpecialityShortInfo>> DeleteSpecialitiesAsync(
        DeleteSpecialitiesRequest request
    );
    public Task<List<SpecialityShortInfo>> SoftDeleteSpecialitiesAsync(
        DeleteSpecialitiesRequest request
    );
    public Task<List<SpecialityShortInfo>> RecoverySpecialitiesAsync(
        RecoverySpecialitiesRequest request
    );
    public Task<SpecialityShortInfo> EditSpecialityAsync(EditSpecialityRequest request);
    public Task<SpecialityDto> GetSpecialityByIdAsync(int id);
    public Task<GetSpecialitiesResponse> GetSpecialitiesAsync(
        int page,
        int pageSize,
        string? search,
        SpecialitySortState sortState,
        DeletedStatus deletedStatus
    );
}
