using Gateway.Contracts.ScheduleService;
using Gateway.Data.Dtos.ScheduleService;
using Gateway.Data.Errors;
using Gateway.Endpoints.ScheduleService.Room.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Endpoints.ScheduleService.Room;

public static class RoomEndpoints
{
    public static IEndpointRouteBuilder Map(this IEndpointRouteBuilder builder)
    {
        string roomTag = "Room";

        builder
            .MapPost(
                "api/room",
                async (
                    [FromBody] CreateRoomRequest request,
                    [FromServices] IRoomService roomService
                ) =>
                {
                    var result = await roomService.CreateRoom(request);

                    return Results.Created("", result);
                }
            )
            .Produces<RoomDto>(StatusCodes.Status201Created)
            .Produces<ValidationError>(StatusCodes.Status400BadRequest)
            .Produces<string>(StatusCodes.Status409Conflict)
            .WithTags(roomTag)
            .WithSummary("Create room")
            .WithDescription("Create room")
            .WithOpenApi(operation =>
            {
                operation.Responses[StatusCodes.Status409Conflict.ToString()].Description =
                    "if room name already exists";

                return operation;
            });

        return builder;
    }
}
