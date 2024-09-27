using Gateway.Endpoints.UserService.Student.Requests;
using Mapster;

namespace Gateway.Mappings;

public static class StudentConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<DeleteStudentsRequest, UserServiceClient.DeleteStudentsRequest>
            .NewConfig()
            .Map(dest => dest.Ids, src => src.StudentsId);
    }
}
