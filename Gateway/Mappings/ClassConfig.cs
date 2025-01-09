using Gateway.Data.Dtos.ScheduleService;
using Gateway.Endpoints.ScheduleService.Class.Requests;
using Google.Protobuf.WellKnownTypes;
using Mapster;

namespace Gateway.Mappings;

public static class ClassConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<ScheduleServiceClient.Class, ClassDto>
            .NewConfig()
            .Map(dest => dest.StartsAt, src => src.StartsAt.ToTimeSpan())
            .Map(dest => dest.EndsAt, src => src.EndsAt.ToTimeSpan())
            .Map(
                dest => dest.ChangeOn,
                src => src.ChangeOn == null ? (DateTime?)null : DateTime.Parse(src.ChangeOn)
            )
            .Map(
                dest => dest.IrrelevantSince,
                src =>
                    src.IrrelevantSince == null
                        ? (DateTime?)null
                        : DateTime.Parse(src.IrrelevantSince)
            );

        TypeAdapterConfig<CreateClassRequest, ScheduleServiceClient.CreateClassRequest>
            .NewConfig()
            .Map(dest => dest.StartsAt, src => src.StartsAt.ToDuration())
            .Map(dest => dest.EndsAt, src => src.EndsAt.ToDuration())
            .Map(
                dest => dest.ChangeOn,
                src => src.ChangeOn == null ? null : src.ChangeOn.ToString()
            )
            .Map(dest => dest.TeacherIds, src => src.TeachersIds);
    }
}
