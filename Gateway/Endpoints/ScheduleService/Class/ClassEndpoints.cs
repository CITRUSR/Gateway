using Gateway.Contracts.ScheduleService;
using Gateway.Data.Dtos.ScheduleService;
using Gateway.Data.Errors;
using Gateway.Endpoints.ScheduleService.Class.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Endpoints.ScheduleService.Class;

public static class ClassEndpoints
{
    public static IEndpointRouteBuilder Map(this IEndpointRouteBuilder builder)
    {
        string classTag = "Class";

        builder
            .MapPost(
                "api/class",
                async (
                    [FromBody] CreateClassRequest request,
                    [FromServices] IClassService classService
                ) =>
                {
                    var result = await classService.CreateClass(request);

                    return Results.Created("", result);
                }
            )
            .Produces<ClassDto>(StatusCodes.Status201Created)
            .Produces<string>(StatusCodes.Status404NotFound)
            .Produces<ValidationError>(StatusCodes.Status400BadRequest)
            .WithTags(classTag)
            .WithSummary("Create class")
            .WithDescription("Creates class")
            .WithOpenApi(operation =>
            {
                operation.Responses[StatusCodes.Status404NotFound.ToString()].Description =
                    "if 1 of the related entities not found";
                return operation;
            });

        return builder;
    }
}
