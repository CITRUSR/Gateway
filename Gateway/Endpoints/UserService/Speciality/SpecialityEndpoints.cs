using Gateway.Data.Enums;
using Gateway.Endpoints.UserService.Speciality.Enums;
using Gateway.Endpoints.UserService.Speciality.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Endpoints.UserService.Speciality;

public static class SpecialityEndpoints
{
    public static IEndpointRouteBuilder Map(IEndpointRouteBuilder builder)
    {
        builder
            .MapGet(
                "api/specialties",
                (
                    [FromQuery] string page,
                    [FromQuery] string pageSize,
                    [FromQuery] string? search,
                    [FromQuery] SpecialitySortState sortState,
                    [FromQuery] DeletedStatus deletedStatus
                ) => { }
            )
            .Produces<GetSpecialitiesResponse>(StatusCodes.Status200OK)
            .WithTags("Specialitiy")
            .WithOpenApi(operation =>
            {
                var sortStateParameter = operation.Parameters[3];
                sortStateParameter.Description =
                    $"**Default value should be {SpecialitySortState.NameAsc}**";

                var deletedStatusParameter = operation.Parameters[4];
                deletedStatusParameter.Description =
                    $"**Default value should be {DeletedStatus.OnlyActive}**";

                operation.Summary = "Get specialities";
                operation.Description =
                    "Get specialities with pagination, filtering, sorting, and deleted status."
                    + "\n\n**Request example:** `/api/specialties?page=5&pageSize=10&sortState=nameAsc&deletedStatus=onlyActive`";

                return operation;
            });

        return builder;
    }
}
