using Gateway.Endpoints.UserService.Teacher.Requests;
using Mapster;

namespace Gateway.Mappings;

public static class TeacherConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<DeleteTeachersRequest, UserServiceClient.DeleteTeachersRequest>
            .NewConfig()
            .Map(dest => dest.Ids, src => src.TeachersId);
    }
}
