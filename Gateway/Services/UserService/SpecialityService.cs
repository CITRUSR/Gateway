using Gateway.Contracts.UserService;
using Gateway.Data.Dtos;
using Gateway.Data.Enums;
using Gateway.Endpoints.UserService.Speciality.Enums;
using Gateway.Endpoints.UserService.Speciality.Requests;
using Gateway.Endpoints.UserService.Speciality.Responses;
using Grpc.Net.Client;

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
        throw new NotImplementedException();
    }

    public async Task<List<SpecialityShortInfo>> DeleteSpecialities(
        DeleteSpecialitiesRequest request
    )
    {
        throw new NotImplementedException();
    }

    public Task<SpecialityShortInfo> EditSpeciality(EditSpecialityRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<GetSpecialitiesResponse> GetSpecialities(
        int page,
        int pageSize,
        string? search,
        SpecialitySortState sortState,
        DeletedStatus deletedStatus
    )
    {
        throw new NotImplementedException();
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
