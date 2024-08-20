using Gateway.Data.Dtos;
using Gateway.Data.Enums;
using Gateway.Endpoints.UserService.Teacher.Enums;
using Gateway.Endpoints.UserService.Teacher.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Endpoints.UserService.Teacher;

public static class TeacherEndpoints
{
    public static IEndpointRouteBuilder Map(IEndpointRouteBuilder builder)
    {
        string teacherTag = "Teacher";

        builder
            .MapGet(
                "api/teachers",
                (
                    [FromQuery] string page,
                    [FromQuery] string pageSize,
                    [FromQuery] string? search,
                    [FromQuery] TeacherFiredStatus firedStatus,
                    [FromQuery] TeacherSortState sortState,
                    [FromQuery] DeletedStatus deletedStatus
                ) => { }
            )
            .Produces<GetTeachersResponse>(StatusCodes.Status200OK)
            .WithTags(teacherTag)
            .WithOpenApi(operation =>
            {
                var firedStatusParameter = operation.Parameters[3];
                firedStatusParameter.Description =
                    $"**Default value should be {TeacherFiredStatus.OnlyActive}**";

                var sortStateParameter = operation.Parameters[4];
                sortStateParameter.Description =
                    $"**Default value should be {TeacherSortState.LastNameAsc}**";

                var deletedStatusParameter = operation.Parameters[5];
                deletedStatusParameter.Description =
                    $"**Default value should be {DeletedStatus.OnlyActive}**";

                operation.Summary = "Get teachers";
                operation.Description =
                    "Get teachers with pagination, filtering, sorting, and deleted status."
                    + "\n\n**Request example:** `/api/teachers?page=5&pageSize=10&firedStatus=OnlyActive&sortState=LastNameAsc&deletedStatus=OnlyActive`";

                return operation;
            });

        builder
            .MapGet("api/teaher", ([FromQuery] int id) => { })
            .Produces<TeacherDto>(StatusCodes.Status200OK)
            .Produces<string>(StatusCodes.Status404NotFound)
            .WithTags(teacherTag)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Get teacher by id";
                operation.Description =
                    "Get teacher by id" + "\n\n**Request example:** `/api/teacher?id=10`";

                return operation;
            });

        builder
            .MapGet("api/teaher/sso", ([FromQuery] int ssoId) => { })
            .Produces<TeacherDto>(StatusCodes.Status200OK)
            .Produces<string>(StatusCodes.Status404NotFound)
            .WithTags(teacherTag)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Get teacher by ssoId";
                operation.Description =
                    "Get teacher by ssoId" + "\n\n**Request example:** `/api/teacher/sso?ssoId=10`";

                return operation;
            });

        return builder;
    }
}
