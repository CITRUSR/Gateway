using Gateway.Contracts.ScheduleService;
using Gateway.Data.Dtos.ScheduleService;
using Gateway.Data.Errors;
using Gateway.Endpoints.ScheduleService.Class.Requests;
using Gateway.Endpoints.ScheduleService.Class.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Endpoints.ScheduleService.Class;

public static class ClassEndpoints
{
    public static IEndpointRouteBuilder Map(this IEndpointRouteBuilder builder)
    {
        string classTag = "Class";

        builder
            .MapGet(
                "api/classes/day/student",
                async ([FromQuery] int Groupid, [FromServices] IClassService classService) =>
                {
                    var result = await classService.GetClassesOnCurrentDateForStudent(Groupid);

                    return Results.Ok(result);
                }
            )
            .Produces<GetClassesOnCurrentDateForStudentResponse>(StatusCodes.Status200OK)
            .Produces<string>(StatusCodes.Status404NotFound)
            .WithTags(classTag)
            .WithSummary("Get classes for day for student")
            .WithDescription("Get classes for day for student");

        builder
            .MapGet(
                "api/class",
                async ([FromQuery] int id, [FromServices] IClassService classService) =>
                {
                    var result = await classService.GetClassById(id);

                    return Results.Ok(result);
                }
            )
            .Produces<ClassDto>(StatusCodes.Status200OK)
            .Produces<string>(StatusCodes.Status404NotFound)
            .WithTags(classTag)
            .WithSummary("Get class by id")
            .WithDescription("Get class by id \n\n**Request example:** `/api/class?id=10`");

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

        builder
            .MapPut(
                "api/class",
                async (
                    [FromBody] UpdateClassRequest request,
                    [FromServices] IClassService classService
                ) =>
                {
                    var result = await classService.UpdateClass(request);

                    return Results.Ok(result);
                }
            )
            .Produces<ClassDto>(StatusCodes.Status200OK)
            .Produces<string>(StatusCodes.Status404NotFound)
            .Produces<ValidationError>(StatusCodes.Status400BadRequest)
            .WithTags(classTag)
            .WithSummary("Update class")
            .WithDescription("Update class")
            .WithOpenApi(operation =>
            {
                operation.Responses[StatusCodes.Status404NotFound.ToString()].Description =
                    "if 1 of the related entities not found";
                return operation;
            });

        builder
            .MapDelete(
                "api/class",
                async ([FromQuery] int id, [FromServices] IClassService classService) =>
                {
                    var result = await classService.DeleteClass(id);

                    return Results.Ok(result);
                }
            )
            .Produces<ClassDto>(StatusCodes.Status200OK)
            .Produces<string>(StatusCodes.Status404NotFound)
            .WithTags(classTag)
            .WithSummary("Delete class")
            .WithDescription("Delete class \n\n**Request example:** `/api/class?id=10`");

        return builder;
    }
}
