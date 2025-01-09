using Gateway.Contracts.ScheduleService;
using Gateway.Data.Dtos.ScheduleService;
using Gateway.Endpoints.ScheduleService.CurrentWeekday.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Endpoints.ScheduleService.CurrentWeekday;

public static class CurrentWeekdayEndpoints
{
    public static IEndpointRouteBuilder Map(this IEndpointRouteBuilder builder)
    {
        string currentWeekdayTag = "CurrentWeekday";

        builder
            .MapGet(
                "api/currentWeekday",
                async ([FromServices] ICurrentWeekdayService currentWeekdayService) =>
                {
                    var result = await currentWeekdayService.GetCurrentWeekday();

                    return Results.Ok(result);
                }
            )
            .Produces<CurrentWeekdayDto>(StatusCodes.Status200OK)
            .Produces<string>(StatusCodes.Status404NotFound)
            .WithTags(currentWeekdayTag)
            .WithSummary("Get current weekday")
            .WithDescription("Get current weekday");

        builder
            .MapPut(
                "api/currentWeekday",
                async (
                    [FromBody] UpdateCurrentWeekdayRequest request,
                    [FromServices] ICurrentWeekdayService currentWeekdayService
                ) =>
                {
                    var result = await currentWeekdayService.UpdateCurrentWeekday(request);

                    return Results.Ok(result);
                }
            )
            .Produces<CurrentWeekdayDto>(StatusCodes.Status200OK)
            .Produces<string>(StatusCodes.Status404NotFound)
            .WithTags(currentWeekdayTag)
            .WithSummary("Update current weekday")
            .WithDescription("Update current weekday");

        builder
            .MapPost(
                "api/currentWeekday",
                async (
                    [FromBody] CreateCurrentWeekdayRequest request,
                    [FromServices] ICurrentWeekdayService currentWeekdayService
                ) =>
                {
                    var result = await currentWeekdayService.CreateCurrentWeekday(request);

                    return Results.Ok(result);
                }
            )
            .Produces<CurrentWeekdayDto>(StatusCodes.Status200OK)
            .Produces<string>(StatusCodes.Status404NotFound)
            .Produces<string>(StatusCodes.Status409Conflict)
            .WithTags(currentWeekdayTag)
            .WithSummary("Create current weekday")
            .WithDescription("Create current weekday")
            .WithOpenApi(operation =>
            {
                operation.Responses[StatusCodes.Status409Conflict.ToString()].Description =
                    "if current weekday already exists";

                return operation;
            });

        return builder;
    }
}
