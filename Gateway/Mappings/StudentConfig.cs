using Gateway.Data.Dtos;
using Gateway.Endpoints.UserService.Student.Requests;
using Google.Protobuf.WellKnownTypes;
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
            .Map(dest => dest.Ids, src => src.StudentsId)
            .Map(dest => dest.DroppedTime, src => src.DroppedTime.ToUniversalTime().ToTimestamp());

        TypeAdapterConfig<EditStudentRequest, UserServiceClient.EditStudentRequest>
            .NewConfig()
            .Map(dest => dest.DroppedOutAt, src => src.DroppedOutAt.ToString());

        TypeAdapterConfig<UserServiceClient.StudentModel, StudentDto>
            .NewConfig()
            .Map(
                dest => dest.DroppedOutAt,
                src =>
                    src.IsDropped
                        ? DateTime.SpecifyKind(
                            src.DroppedOutAt.ToDateTime(),
                            DateTimeKind.Unspecified
                        )
                        : (DateTime?)null
            );
    }
}
