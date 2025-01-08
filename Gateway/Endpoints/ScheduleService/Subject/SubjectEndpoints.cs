using Gateway.Contracts.ScheduleService;
using Gateway.Data.Common;
using Gateway.Data.Dtos.ScheduleService;
using Gateway.Data.Enums;
using Gateway.Data.Errors;
using Gateway.Endpoints.ScheduleService.Subject.Enums;
using Gateway.Endpoints.ScheduleService.Subject.Requests;
using Gateway.Endpoints.ScheduleService.Subject.Responses;
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

        builder
            .MapGet(
                "api/subject",
                async ([FromQuery] int id, [FromServices] ISubjectService subjectService) =>
                {
                    var result = await subjectService.GetSubjectById(id);

                    return Results.Ok(result);
                }
            )
            .Produces<SubjectDto>(StatusCodes.Status200OK)
            .Produces<string>(StatusCodes.Status404NotFound)
            .WithTags(subjectTag)
            .WithSummary("Get subject by id")
            .WithDescription("Get subject by id \n\n**Request example:** `/api/subject?id=10`");

        builder
            .MapGet(
                "api/subjects",
                async (
                    [FromQuery] int page,
                    [FromQuery] int pageSize,
                    [FromQuery] string? searchString,
                    [FromQuery] SubjectFilterState filterBy,
                    [FromQuery] OrderState orderBy,
                    [FromServices] ISubjectService subjectService
                ) =>
                {
                    var pagParameters = new PaginationParameters()
                    {
                        Page = page,
                        PageSize = pageSize,
                    };

                    var filter = new SubjectFilter(searchString, filterBy, orderBy);

                    var request = new GetSubjectsRequest(filter, pagParameters);

                    var result = await subjectService.GetSubjects(request);

                    return Results.Ok(result);
                }
            )
            .Produces<GetSubjectsResponse>(StatusCodes.Status200OK)
            .WithTags(subjectTag)
            .WithSummary("Get subjects")
            .WithDescription(
                "Get subject with pagination and filtration"
                    + "\n\n**Request example:** `/api/subjects?page=5&pageSize=10&searchString=Ma&filterBy=Name&orderBy=Asc`"
            );

        builder
            .MapPut(
                "api/subject",
                async (
                    [FromBody] UpdateSubjectRequest request,
                    [FromServices] ISubjectService subjectService
                ) =>
                {
                    var result = await subjectService.UpdateSubject(request);

                    return Results.Ok(result);
                }
            )
            .Produces<SubjectDto>(StatusCodes.Status200OK)
            .Produces<ValidationError>(StatusCodes.Status400BadRequest)
            .Produces<string>(StatusCodes.Status409Conflict)
            .Produces<string>(StatusCodes.Status404NotFound)
            .WithTags(subjectTag)
            .WithSummary("Update subject")
            .WithDescription("Update subject")
            .WithOpenApi(operation =>
            {
                operation.Responses[StatusCodes.Status409Conflict.ToString()].Description =
                    "if subject with this name already exists";

                return operation;
            });

        builder
            .MapDelete(
                "api/subject",
                async ([FromQuery] int id, [FromServices] ISubjectService subjectService) =>
                {
                    var result = await subjectService.DeleteSubject(id);

                    return Results.Ok(result);
                }
            )
            .Produces<SubjectDto>(StatusCodes.Status200OK)
            .Produces<string>(StatusCodes.Status404NotFound)
            .WithTags(subjectTag)
            .WithSummary("Delete subject")
            .WithDescription("Delete subject");

        return builder;
    }
}
