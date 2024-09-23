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
    }
}
