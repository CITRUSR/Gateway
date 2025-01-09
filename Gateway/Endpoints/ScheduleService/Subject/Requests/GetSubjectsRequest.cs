using Gateway.Data.Common;

namespace Gateway.Endpoints.ScheduleService.Subject.Requests;

public record GetSubjectsRequest(SubjectFilter Filter, PaginationParameters PaginationParameters);
