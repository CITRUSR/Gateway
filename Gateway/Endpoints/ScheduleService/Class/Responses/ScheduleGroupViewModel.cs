using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.ScheduleService.Class.Responses;

public record ScheduleGroupViewModel(
    [property: Required()] int Id,
    [property: Required()] string FullName
);
