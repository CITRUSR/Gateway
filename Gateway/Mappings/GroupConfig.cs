using Gateway.Data.Dtos;
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

        TypeAdapterConfig<DeleteGroupsRequest, UserServiceClient.DeleteGroupsRequest>
            .NewConfig()
            .Map(dest => dest.Ids, src => src.GroupsId);

        TypeAdapterConfig<UserServiceClient.GroupModel, GroupDto>
            .NewConfig()
            .Map(
                dest => dest.GraduatedAt,
                src =>
                    src.IsGraduated
                        ? DateTime.SpecifyKind(
                            src.GraduatedAt.ToDateTime(),
                            DateTimeKind.Unspecified
                        )
                        : (DateTime?)null
            )
            .Map(
                dest => dest.StartedAt,
                src => DateTime.SpecifyKind(src.StartedAt.ToDateTime(), DateTimeKind.Unspecified)
            );

        TypeAdapterConfig<GraduateGroupsRequest, UserServiceClient.GraduateGroupsRequest>
            .NewConfig()
            .Map(dest => dest.GraduatedTime, src => src.GraduatedTime.ToTimestamp());

        TypeAdapterConfig<RecoveryGroupsRequest, UserServiceClient.RecoveryGroupsRequest>
            .NewConfig()
            .Map(dest => dest.Ids, src => src.GroupsId);
    }
}
