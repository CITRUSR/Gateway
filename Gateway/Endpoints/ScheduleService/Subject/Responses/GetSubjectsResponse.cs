using System.ComponentModel.DataAnnotations;
using Gateway.Data.Dtos.ScheduleService;

namespace Gateway.Endpoints.ScheduleService.Subject.Responses;

public record GetSubjectsResponse(List<SubjectDto> Subjects, [property: Required()] int LastPage);
