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

        return builder;
    }
}
