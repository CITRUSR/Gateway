using Gateway.Endpoints.UserService.Speciality.Requests;
using Mapster;

namespace Gateway.Mappings;

public static class SpecialityConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<DeleteSpecialitiesRequest, UserServiceClient.DeleteSpecialitiesRequest>
            .NewConfig()
            .Map(dest => dest.Ids, src => src.SpecialitiesId);

        TypeAdapterConfig<
            DeleteSpecialitiesRequest,
            UserServiceClient.SoftDeleteSpecialitiesRequest
        >
            .NewConfig()
            .Map(dest => dest.Ids, src => src.SpecialitiesId);

        TypeAdapterConfig<
            RecoverySpecialitiesRequest,
            UserServiceClient.RecoverySpecialitiesRequest
        >
            .NewConfig()
            .Map(dest => dest.Ids, src => src.SpecialitiesId);
    }
}
