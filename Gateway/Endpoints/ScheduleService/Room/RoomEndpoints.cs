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

        builder
            .MapGet(
                "api/room",
                async ([FromQuery] int id, [FromServices] IRoomService roomService) =>
                {
                    var result = await roomService.GetRoomById(id);

                    return Results.Ok(result);
                }
            )
            .Produces<RoomDto>(StatusCodes.Status200OK)
            .Produces<string>(StatusCodes.Status404NotFound)
            .WithTags(roomTag)
            .WithSummary("Get room by id")
            .WithDescription("Get room by id");

        builder
            .MapPut(
                "api/room",
                async (
                    [FromBody] UpdateRoomRequest request,
                    [FromServices] IRoomService roomService
                ) =>
                {
                    var result = await roomService.UpdateRoom(request);

                    return Results.Ok(result);
                }
            )
            .Produces<RoomDto>(StatusCodes.Status200OK)
            .Produces<string>(StatusCodes.Status409Conflict)
            .Produces<string>(StatusCodes.Status404NotFound)
            .WithTags(roomTag)
            .WithSummary("Update room")
            .WithDescription("Update room")
            .WithOpenApi(operation =>
            {
                operation.Responses[StatusCodes.Status409Conflict.ToString()].Description =
                    "if room name already exists";

                return operation;
            });

        return builder;
    }
}
