using Gateway.Contracts.ScheduleService;
using Gateway.Data.Dtos.ScheduleService;
using Gateway.Data.Errors;
using Gateway.Endpoints.ScheduleService.Subject.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Endpoints.ScheduleService.Subject;

public static class SubjectEndpoints
{
    public static IEndpointRouteBuilder Map(this IEndpointRouteBuilder builder)
    {
        string subjectTag = "Subject";

        builder
            .MapPost(
                "api/subject",
                async (
                    [FromBody] CreateSubjectRequest request,
                    [FromServices] ISubjectService subjectService
                ) =>
                {
                    var result = await subjectService.CreateSubject(request);

                    return Results.Created("", result);
                }
            )
            .Produces<SubjectDto>(StatusCodes.Status201Created)
            .Produces<ValidationError>(StatusCodes.Status400BadRequest)
            .Produces<string>(StatusCodes.Status409Conflict)
            .WithTags(subjectTag)
            .WithSummary("Create subject")
            .WithDescription("Create subject")
            .WithOpenApi(operation =>
            {
                operation.Responses[StatusCodes.Status409Conflict.ToString()].Description =
                    "if subject with this name already exists";

                return operation;
            });

        return builder;
    }
}
