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

        TypeAdapterConfig<DropOutStudentsRequest, UserServiceClient.DropOutStudentsRequest>
            .NewConfig()
            .Map(dest => dest.Ids, src => src.StudentsId);

        TypeAdapterConfig<RecoveryStudentsRequest, UserServiceClient.RecoveryStudentsRequest>
            .NewConfig()
            .Map(dest => dest.Ids, src => src.StudentsId);

        TypeAdapterConfig<DeleteStudentsRequest, UserServiceClient.SoftDeleteStudentsRequest>
            .NewConfig()
            .Map(dest => dest.Ids, src => src.StudentsId);
    }
}
