using Gateway.Contracts.UserService;
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
                async (
                    [FromQuery] int page,
                    [FromQuery] int pageSize,
                    [FromQuery] string? search,
                    [FromQuery] SpecialitySortState sortState,
                    [FromQuery] DeletedStatus deletedStatus,
                    ISpecialityService specialityService
                ) =>
                {
                    var result = await specialityService.GetSpecialities(
                        page,
                        pageSize,
                        search,
                        sortState,
                        deletedStatus
                    );

                    return Results.Ok(result);
                }
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
            .MapGet(
                "api/speciality",
                async ([FromQuery] int id, ISpecialityService specialityService) =>
                {
                    var result = await specialityService.GetSpecialityById(id);

                    return Results.Ok(result);
                }
            )
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
            .MapPost(
                "api/speciality",
                async (
                    [FromBody] CreateSpecialityRequest request,
                    ISpecialityService specialityService
                ) =>
                {
                    var result = await specialityService.CreateSpeciality(request);

                    return Results.Created("", result);
                }
            )
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
            .MapDelete(
                "api/specialities",
                async (
                    [FromBody] DeleteSpecialitiesRequest request,
                    ISpecialityService specialityService
                ) =>
                {
                    var result = await specialityService.DeleteSpecialities(request);

                    return Results.Ok(result);
                }
            )
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
                async (
                    [FromBody] DeleteSpecialitiesRequest request,
                    ISpecialityService specialityService
                ) =>
                {
                    var result = await specialityService.SoftDeleteSpecialities(request);

                    return Results.Ok(result);
                }
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
                async (
                    [FromBody] RecoverySpecialitiesRequest request,
                    ISpecialityService specialityService
                ) =>
                {
                    var result = await specialityService.RecoverySpecialities(request);

                    return Results.Ok(result);
                }
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
            .MapPut(
                "api/speciality",
                async (
                    [FromBody] EditSpecialityRequest request,
                    ISpecialityService specialityService
                ) =>
                {
                    var result = await specialityService.EditSpeciality(request);

                    return Results.Ok(result);
                }
            )
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
