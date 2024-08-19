using Gateway.Data.Enums;
using Gateway.Endpoints.UserService.Group.Enums;
using Gateway.Endpoints.UserService.Group.Requests;
using Gateway.Endpoints.UserService.Group.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Endpoints.UserService.Group;

public static class GroupEndpoints
{
    public static IEndpointRouteBuilder Map(IEndpointRouteBuilder builder)
    {
        string groupTag = "Group";

        builder
            .MapGet(
                "api/groups",
                (
                    [FromQuery] string page,
                    [FromQuery] string pageSize,
                    [FromQuery] string? search,
                    [FromQuery] GroupGraduatedStatus graduatedStatus,
                    [FromQuery] GroupSortState sortState,
                    [FromQuery] DeletedStatus deletedStatus
                ) => { }
            )
            .Produces<GetGroupsResponse>(StatusCodes.Status200OK)
            .WithTags(groupTag)
            .WithOpenApi(operation =>
            {
                var graduatedStatusParameter = operation.Parameters[3];
                graduatedStatusParameter.Description =
                    $"**Default value should be {GroupGraduatedStatus.OnlyActive}**";

                var sortStateParameter = operation.Parameters[4];
                sortStateParameter.Description =
                    $"**Default value should be {GroupSortState.GroupAsc}**";

                var deletedStatusParameter = operation.Parameters[5];
                deletedStatusParameter.Description =
                    $"**Default value should be {DeletedStatus.OnlyActive}**";

                operation.Summary = "Get groups";
                operation.Description =
                    "Get groups with pagination, filtering, sorting, and deleted status."
                    + "\n\n**Request example:** `/api/groups?page=5&pageSize=10&graduatedStatus=OnlyActive&sortState=GroupAsc&deletedStatus=OnlyActive`";

                return operation;
            });

        builder
            .MapGet("api/group", ([FromQuery] int id) => { })
            .Produces<GroupDetailInfo>(StatusCodes.Status200OK)
            .Produces<string>(StatusCodes.Status404NotFound)
            .WithTags(groupTag)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Get group by id";
                operation.Description =
                    "Get group by id" + "\n\n**Request example:** `/api/group?id=10`";

                return operation;
            });

        builder
            .MapPost("api/group", ([FromBody] CreateGroupRequest request) => { })
            .Produces<GroupShortInfo>(StatusCodes.Status200OK)
            .Produces<string>(StatusCodes.Status404NotFound)
            .WithTags(groupTag)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Create group";
                operation.Description = "Create group";

                return operation;
            });

        builder
            .MapDelete("api/groups", ([FromBody] DeleteGroupsRequest request) => { })
            .Produces<List<GroupShortInfo>>(StatusCodes.Status200OK)
            .Produces<List<string>>(StatusCodes.Status404NotFound)
            .WithTags(groupTag)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Delete groups";
                operation.Description = "Delete groups";

                return operation;
            });

        builder
            .MapDelete("api/groups/soft", ([FromBody] DeleteGroupsRequest request) => { })
            .Produces<List<GroupShortInfo>>(StatusCodes.Status200OK)
            .Produces<List<string>>(StatusCodes.Status404NotFound)
            .WithTags(groupTag)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Soft delete groups";
                operation.Description = "Soft delete groups";

                return operation;
            });

        return builder;
    }
}
