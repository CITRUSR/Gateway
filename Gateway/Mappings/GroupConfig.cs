using Gateway.Endpoints.UserService.Group.Requests;
using Google.Protobuf.WellKnownTypes;
using Mapster;

namespace Gateway.Mappings;

public static class GroupConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<CreateGroupRequest, UserServiceClient.CreateGroupRequest>
            .NewConfig()
            .Map(dest => dest.StartedAt, src => src.StartedAt.ToTimestamp());
    }
}
