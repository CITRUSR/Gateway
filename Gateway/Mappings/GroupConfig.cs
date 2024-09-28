using Gateway.Endpoints.UserService.Group.Requests;
using Mapster;

namespace Gateway.Mappings;

public static class GroupConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<DeleteGroupsRequest, UserServiceClient.DeleteGroupsRequest>
            .NewConfig()
            .Map(dest => dest.Ids, src => src.GroupsId);

        TypeAdapterConfig<RecoveryGroupsRequest, UserServiceClient.RecoveryGroupsRequest>
            .NewConfig()
            .Map(dest => dest.Ids, src => src.GroupsId);

        TypeAdapterConfig<DeleteGroupsRequest, UserServiceClient.SoftDeleteGroupsRequest>
            .NewConfig()
            .Map(dest => dest.Ids, src => src.GroupsId);

        TypeAdapterConfig<
            TransferGroupsToNextCourseRequest,
            UserServiceClient.TransferGroupsToNextCourseRequest
        >
            .NewConfig()
            .Map(dest => dest.IdGroups, src => src.GroupsId);

        TypeAdapterConfig<
            TransferGroupsToNextSemesterRequest,
            UserServiceClient.TransferGroupsToNextSemesterRequest
        >
            .NewConfig()
            .Map(dest => dest.IdGroups, src => src.GroupsId);
    }
}
