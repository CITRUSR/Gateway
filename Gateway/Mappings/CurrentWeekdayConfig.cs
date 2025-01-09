using Gateway.Data.Dtos.ScheduleService;
using Gateway.Endpoints.ScheduleService.CurrentWeekday.Requests;
using Google.Protobuf.WellKnownTypes;
using Mapster;

namespace Gateway.Mappings;

public static class CurrentWeekdayConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<ScheduleServiceClient.CurrentWeekday, CurrentWeekdayDto>
            .NewConfig()
            .Map(dest => dest.Interval, src => src.Interval.ToTimeSpan())
            .Map(
                dest => dest.UpdatedAt,
                src => src.UpdatedAt != null ? DateTime.Parse(src.UpdatedAt) : (DateTime?)null
            );

        TypeAdapterConfig<
            UpdateCurrentWeekdayRequest,
            ScheduleServiceClient.UpdateCurrentWeekdayRequest
        >
            .NewConfig()
            .Map(dest => dest.Interval, src => src.Interval.ToDuration())
            .Map(dest => dest.UpdateTime, src => src.UpdateTime.ToTimestamp());
    }
}
