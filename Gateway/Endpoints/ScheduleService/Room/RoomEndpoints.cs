using Gateway.Contracts.ScheduleService;
using Gateway.Data.Common;
using Gateway.Data.Dtos.ScheduleService;
using Gateway.Data.Enums;
using Gateway.Data.Errors;
using Gateway.Endpoints.ScheduleService.Room.Enums;
using Gateway.Endpoints.ScheduleService.Room.Requests;
using Gateway.Endpoints.ScheduleService.Room.Responses;
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
                    var result = await roomService.CreateRoomAsync(request);

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
                    var result = await roomService.GetRoomByIdAsync(id);

                    return Results.Ok(result);
                }
            )
            .Produces<RoomDto>(StatusCodes.Status200OK)
            .Produces<string>(StatusCodes.Status404NotFound)
            .WithTags(roomTag)
            .WithSummary("Get room by id")
            .WithDescription("Get room by id");

        builder
            .MapGet(
                "api/rooms",
                async (
                    [FromQuery] int page,
                    [FromQuery] int pageSize,
                    [FromQuery] string? searchString,
                    [FromQuery] RoomFilterState filterBy,
                    [FromQuery] OrderState orderBy,
                    [FromServices] IRoomService roomService
                ) =>
                {
                    var roomFilter = new RoomFilter(searchString, filterBy, orderBy);

                    var pagParameters = new PaginationParameters()
                    {
                        Page = page,
                        PageSize = pageSize,
                    };

                    var request = new GetRoomsRequest(roomFilter, pagParameters);

                    var result = await roomService.GetRoomsAsync(request);

                    return Results.Ok(result);
                }
            )
            .Produces<GetRoomsResponse>(StatusCodes.Status200OK)
            .WithTags(roomTag)
            .WithSummary("Get rooms")
            .WithDescription(
                "Get rooms with filtering and pagination"
                    + "\n\n**Request example:** `/api/rooms?page=5&pageSize=10&searchString=40&filterBy=Name&orderBy=Asc`"
            );

        builder
            .MapPut(
                "api/room",
                async (
                    [FromBody] UpdateRoomRequest request,
                    [FromServices] IRoomService roomService
                ) =>
                {
                    var result = await roomService.UpdateRoomAsync(request);

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

        builder
            .MapDelete(
                "api/room",
                async ([FromQuery] int id, [FromServices] IRoomService roomService) =>
                {
                    var result = await roomService.DeleteRoomAsync(id);

                    return Results.Ok(result);
                }
            )
            .Produces<RoomDto>(StatusCodes.Status200OK)
            .Produces<string>(StatusCodes.Status404NotFound)
            .WithTags(roomTag)
            .WithSummary("Delete room")
            .WithDescription("Delete room");

        return builder;
    }
}
