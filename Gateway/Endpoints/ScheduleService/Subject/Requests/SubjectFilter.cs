using Gateway.Data.Enums;
using Gateway.Endpoints.ScheduleService.Subject.Enums;

namespace Gateway.Endpoints.ScheduleService.Subject.Requests;

public record SubjectFilter(
    string? SearchString,
    SubjectFilterState FilterBy,
    OrderState OrderState
);
