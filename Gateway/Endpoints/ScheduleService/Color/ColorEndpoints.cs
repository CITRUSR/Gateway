using Gateway.Contracts.ScheduleService;
using Gateway.Data.Dtos.ScheduleService;
using Gateway.Data.Errors;
using Gateway.Endpoints.ScheduleService.Color.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Endpoints.ScheduleService.Color;

public static class ColorEndpoints
{
    public static IEndpointRouteBuilder Map(this IEndpointRouteBuilder builder)
    {
        string colorTag = "Color";

        builder
            .MapPost(
                "api/color",
                async (
                    [FromBody] CreateColorRequest request,
                    [FromServices] IColorService colorSerice
                ) =>
                {
                    var result = await colorSerice.CreateColor(request);

                    return Results.Created("", result);
                }
            )
            .Produces<ColorDto>(StatusCodes.Status201Created)
            .Produces<ValidationError>(StatusCodes.Status400BadRequest)
            .Produces<string>(StatusCodes.Status409Conflict)
            .WithTags(colorTag)
            .WithSummary("Create color")
            .WithDescription("Create color")
            .WithOpenApi(operation =>
            {
                operation.Responses[StatusCodes.Status409Conflict.ToString()].Description =
                    "if color with this name already exists";

                return operation;
            });

        return builder;
    }
}
