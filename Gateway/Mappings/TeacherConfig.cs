using Gateway.Endpoints.UserService.Teacher.Requests;
using Google.Protobuf.WellKnownTypes;
using Mapster;

namespace Gateway.Mappings;

public static class TeacherConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<DeleteTeachersRequest, UserServiceClient.DeleteTeachersRequest>
            .NewConfig()
            .Map(dest => dest.Ids, src => src.TeachersId);

        TypeAdapterConfig<DeleteTeachersRequest, UserServiceClient.SoftDeleteTeachersRequest>
            .NewConfig()
            .Map(dest => dest.Ids, src => src.TeachersId);

        TypeAdapterConfig<FireTeachersRequest, UserServiceClient.FireTeachersRequest>
            .NewConfig()
            .Map(dest => dest.Ids, src => src.TeachersId);

        TypeAdapterConfig<RecoveryTeachersRequest, UserServiceClient.RecoverySpecialitiesRequest>
            .NewConfig()
            .Map(dest => dest.Ids, src => src.TeachersId);
    }
}
