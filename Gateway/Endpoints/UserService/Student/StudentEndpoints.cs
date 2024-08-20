using Gateway.Data.Dtos;
using Gateway.Data.Enums;
using Gateway.Endpoints.UserService.Student.Enums;
using Gateway.Endpoints.UserService.Student.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Endpoints.UserService.Student;

public static class StudentEndpoints
{
    public static IEndpointRouteBuilder Map(IEndpointRouteBuilder builder)
    {
        string studentTag = "Student";

        builder
            .MapGet(
                "api/students",
                (
                    [FromQuery] string page,
                    [FromQuery] string pageSize,
                    [FromQuery] string? search,
                    [FromQuery] StudentDroppedOutStatus droppedOutStatus,
                    [FromQuery] StudentSortState sortState,
                    [FromQuery] DeletedStatus deletedStatus
                ) => { }
            )
            .Produces<GetStudentsResponse>(StatusCodes.Status200OK)
            .WithTags(studentTag)
            .WithOpenApi(operation =>
            {
                var droppedOutStatusParameter = operation.Parameters[3];
                droppedOutStatusParameter.Description =
                    $"**Default value should be {StudentDroppedOutStatus.OnlyActive}**";

                var sortStateParameter = operation.Parameters[4];
                sortStateParameter.Description =
                    $"**Default value should be {StudentSortState.LastNameAsc}**";

                var deletedStatusParameter = operation.Parameters[5];
                deletedStatusParameter.Description =
                    $"**Default value should be {DeletedStatus.OnlyActive}**";

                operation.Summary = "Get students";
                operation.Description =
                    "Get students with pagination, filtering, sorting, and deleted status."
                    + "\n\n**Request example:** `/api/groups?page=5&pageSize=10&droppedOutStatus=OnlyActive&sortState=LastNameAsc&deletedStatus=OnlyActive`";

                return operation;
            });

        builder
            .MapGet("api/student", ([FromQuery] int id) => { })
            .Produces<StudentDto>(StatusCodes.Status200OK)
            .Produces<string>(StatusCodes.Status404NotFound)
            .WithTags(studentTag)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Get student by id";
                operation.Description =
                    "Get student by id" + "\n\n**Request example:** `/api/group?id=10`";

                return operation;
            });

        builder
            .MapGet("api/student/sso", ([FromQuery] int ssoId) => { })
            .Produces<StudentDto>(StatusCodes.Status200OK)
            .Produces<string>(StatusCodes.Status404NotFound)
            .WithTags(studentTag)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Get student by ssoId";
                operation.Description =
                    "Get student by ssoId" + "\n\n**Request example:** `/api/group/sso?ssoId=10`";

                return operation;
            });

        return builder;
    }
}
