using Gateway.Data.Enums;
using Gateway.Endpoints.UserService.Group.Enums;
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

        return builder;
    }
}
