using Gateway.Contracts.UserService;
using Gateway.Data.Dtos;
using Gateway.Data.Enums;
using Gateway.Endpoints.UserService.Speciality.Enums;
using Gateway.Endpoints.UserService.Speciality.Requests;
using Gateway.Endpoints.UserService.Speciality.Responses;
using Grpc.Net.Client;
using Mapster;

namespace Gateway.Services.UserService;

public class SpecialityService : ISpecialityService
{
    private readonly UserServiceClient.SpecialityService.SpecialityServiceClient _specialityService;

    public SpecialityService(IConfiguration configuration)
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

        _specialityService = new UserServiceClient.SpecialityService.SpecialityServiceClient(
            channel
        );
    }

    public async Task<SpecialityShortInfo> CreateSpeciality(CreateSpecialityRequest request)
    {
        var grpcRequest = request.Adapt<UserServiceClient.CreateSpecialityRequest>();

        var result = await _specialityService.CreateSpecialityAsync(grpcRequest);

        return result.Adapt<SpecialityShortInfo>();
    }

    public async Task<List<SpecialityShortInfo>> DeleteSpecialities(
        DeleteSpecialitiesRequest request
    )
    {
        var grpcRequest = request.Adapt<UserServiceClient.DeleteSpecialitiesRequest>();

        var result = await _specialityService.DeleteSpecialitiesAsync(grpcRequest);

        return result.Specialities.Adapt<List<SpecialityShortInfo>>();
    }

    public async Task<SpecialityShortInfo> EditSpeciality(EditSpecialityRequest request)
    {
        var grpcRequest = request.Adapt<UserServiceClient.EditSpecialityRequest>();

        var result = await _specialityService.EditSpecialityAsync(grpcRequest);

        return result.Adapt<SpecialityShortInfo>();
    }

    public async Task<GetSpecialitiesResponse> GetSpecialities(
        int page,
        int pageSize,
        string? search,
        SpecialitySortState sortState,
        DeletedStatus deletedStatus
    )
    {
        var grpcRequest = new UserServiceClient.GetSpecialitiesRequest
        {
            DeletedStatus = (UserServiceClient.DeletedStatus)deletedStatus,
            Page = page,
            PageSize = pageSize,
            SearchString = search,
            SortState = (UserServiceClient.SpecialitySortState)sortState,
        };

        var result = await _specialityService.GetSpecialitiesAsync(grpcRequest);

        return result.Adapt<GetSpecialitiesResponse>();
    }

    public Task<SpecialityDto> GetSpecialityById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<SpecialityShortInfo>> RecoverySpecialities(RecoverySpecialitiesRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<List<SpecialityShortInfo>> SoftDeleteSpecialities(
        DeleteSpecialitiesRequest request
    )
    {
        throw new NotImplementedException();
    }
}
