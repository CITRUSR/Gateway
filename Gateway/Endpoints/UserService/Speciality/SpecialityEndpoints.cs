using Gateway.Data.Dtos;
using Gateway.Data.Enums;
using Gateway.Data.Errors;
using Gateway.Endpoints.UserService.Speciality.Enums;
using Gateway.Endpoints.UserService.Speciality.Requests;
using Gateway.Endpoints.UserService.Speciality.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Endpoints.UserService.Speciality;

public static class SpecialityEndpoints
{
    public static IEndpointRouteBuilder Map(IEndpointRouteBuilder builder)
    {
        string specialityTag = "Speciality";

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
            .WithTags(specialityTag)
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

        builder
            .MapGet("api/speciality", ([FromQuery] int id) => { })
            .Produces<SpecialityDto>(StatusCodes.Status200OK)
            .Produces<string>(StatusCodes.Status404NotFound)
            .WithTags(specialityTag)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Get speciality by id";
                operation.Description =
                    "Get speciality by id" + "\n\n**Request example:** `/api/speciality?id=10`";

                return operation;
            });

        builder
            .MapPost("api/speciality", ([FromBody] CreateSpecialityRequest request) => { })
            .Produces<SpecialityShortInfo>(StatusCodes.Status201Created)
            .Produces<ValidationError>(StatusCodes.Status400BadRequest)
            .WithTags(specialityTag)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Create speciality";
                operation.Description = "Create speciality";

                return operation;
            });

        builder
            .MapDelete("api/specialities", ([FromBody] DeleteSpecialitiesRequest request) => { })
            .Produces<List<SpecialityShortInfo>>(StatusCodes.Status200OK)
            .Produces<List<string>>(StatusCodes.Status404NotFound)
            .WithTags(specialityTag)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Delete specialities";
                operation.Description = "Delete specialities";

                return operation;
            });

        builder
            .MapDelete(
                "api/specialities/soft",
                ([FromBody] DeleteSpecialitiesRequest request) => { }
            )
            .Produces<List<SpecialityShortInfo>>(StatusCodes.Status200OK)
            .Produces<List<string>>(StatusCodes.Status404NotFound)
            .WithTags(specialityTag)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Soft delete specialities";
                operation.Description = "Soft delete specialities";

                return operation;
            });

        builder
            .MapPatch(
                "api/specialities/recovery",
                ([FromBody] RecoverySpecialitiesRequest request) => { }
            )
            .Produces<List<SpecialityShortInfo>>(StatusCodes.Status200OK)
            .Produces<List<string>>(StatusCodes.Status404NotFound)
            .WithTags(specialityTag)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Recovery specialities";
                operation.Description = "Recovery specialities";

                return operation;
            });

        builder
            .MapPut("api/speciality", ([FromBody] EditSpecialityRequest request) => { })
            .Produces<SpecialityShortInfo>(StatusCodes.Status200OK)
            .Produces<ValidationError>(StatusCodes.Status400BadRequest)
            .Produces<string>(StatusCodes.Status404NotFound)
            .WithTags(specialityTag)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Edit speciality";
                operation.Description = "Edit speciality";

                return operation;
            });

        return builder;
    }
}
