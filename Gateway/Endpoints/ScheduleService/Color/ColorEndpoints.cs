using Gateway.Contracts.ScheduleService;
using Gateway.Data.Dtos.ScheduleService;
using Gateway.Data.Errors;
using Gateway.Endpoints.ScheduleService.Color.Requests;
using Gateway.Endpoints.ScheduleService.Color.Responses;
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
                    var result = await colorSerice.CreateColorAsync(request);

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

        builder
            .MapGet(
                "api/color",
                async ([FromQuery] int id, [FromServices] IColorService colorSercice) =>
                {
                    var result = await colorSercice.GetColorByIdAsync(id);

                    return Results.Ok(result);
                }
            )
            .Produces<ColorDto>(StatusCodes.Status200OK)
            .Produces<string>(StatusCodes.Status404NotFound)
            .WithTags(colorTag)
            .WithSummary("Get color by id")
            .WithDescription("Get color by id \n\n**Request example:** `/api/color?id=10`");

        builder
            .MapGet(
                "api/colors",
                async ([FromServices] IColorService colorSercice) =>
                {
                    var result = await colorSercice.GetColorsAsync();

                    return Results.Ok(result);
                }
            )
            .Produces<List<ColorViewModel>>(StatusCodes.Status200OK)
            .WithTags(colorTag)
            .WithSummary("Get colors")
            .WithDescription("Get colors");

        builder
            .MapPut(
                "api/color",
                async (
                    [FromBody] UpdateColorRequest request,
                    [FromServices] IColorService colorSercice
                ) =>
                {
                    var result = await colorSercice.UpdateColorAsync(request);

                    return Results.Ok(result);
                }
            )
            .Produces<ColorDto>(StatusCodes.Status200OK)
            .Produces<ValidationError>(StatusCodes.Status400BadRequest)
            .Produces<string>(StatusCodes.Status409Conflict)
            .WithTags(colorTag)
            .WithSummary("Update color")
            .WithDescription("Update color")
            .WithOpenApi(operation =>
            {
                operation.Responses[StatusCodes.Status409Conflict.ToString()].Description =
                    "if color with this name already exists";

                return operation;
            });

        builder
            .MapDelete(
                "/color",
                async ([FromQuery] int id, [FromServices] IColorService colorService) =>
                {
                    var result = await colorService.DeleteColorAsync(id);

                    return Results.Ok(result);
                }
            )
            .Produces<ColorDto>(StatusCodes.Status200OK)
            .Produces<string>(StatusCodes.Status404NotFound)
            .WithTags(colorTag)
            .WithSummary("Delete color")
            .WithDescription("Delete color \n\n**Request example:** `/api/color?id=10`");

        return builder;
    }
}
