using Gateway.Data.Dtos;
using Gateway.Data.Enums;
using Gateway.Data.Errors;
using Gateway.Endpoints.UserService.Student.Enums;
using Gateway.Endpoints.UserService.Student.Requests;
using Gateway.Endpoints.UserService.Student.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

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
                    + "\n\n**Request example:** `/api/students?page=5&pageSize=10&droppedOutStatus=OnlyActive&sortState=LastNameAsc&deletedStatus=OnlyActive`";

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
                    "Get student by id" + "\n\n**Request example:** `/api/student?id=10`";

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
                    "Get student by ssoId" + "\n\n**Request example:** `/api/student/sso?ssoId=10`";

                return operation;
            });

        builder
            .MapGet("api/students/group", ([FromQuery] int groupId) => { })
            .Produces<List<StudentViewModel>>(StatusCodes.Status200OK)
            .WithTags(studentTag)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Get students by groupId";
                operation.Description =
                    "Get students by groupId"
                    + "\n\n**Request example:** `/api/students/group?groupId=10`";

                operation.Responses.Add(
                    StatusCodes.Status404NotFound.ToString(),
                    new OpenApiResponse
                    {
                        Description = "Not Found\n\nGroup not found",
                        Content = new Dictionary<string, OpenApiMediaType>
                        {
                            ["application/json"] = new OpenApiMediaType
                            {
                                Schema = new OpenApiSchema { Type = "string" },
                            },
                        },
                    }
                );

                return operation;
            });

        builder
            .MapPost("api/student", ([FromBody] CreateStudentRequest request) => { })
            .Produces<StudentShortInfo>(StatusCodes.Status201Created)
            .Produces<ValidationError>(StatusCodes.Status400BadRequest)
            .WithTags(studentTag)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Create student";
                operation.Description = "Create student";

                operation.Responses.Add(
                    StatusCodes.Status404NotFound.ToString(),
                    new OpenApiResponse
                    {
                        Description = "Not Found\n\nGroup not found",
                        Content = new Dictionary<string, OpenApiMediaType>
                        {
                            ["application/json"] = new OpenApiMediaType
                            {
                                Schema = new OpenApiSchema { Type = "string" },
                            },
                        },
                    }
                );

                return operation;
            });

        builder
            .MapDelete("api/students", ([FromBody] DeleteStudentsRequest request) => { })
            .Produces<List<StudentShortInfo>>(StatusCodes.Status200OK)
            .Produces<string>(StatusCodes.Status404NotFound)
            .WithTags(studentTag)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Delete students";
                operation.Description = "Delete students";

                return operation;
            });

        builder
            .MapDelete("api/students/soft", ([FromBody] DeleteStudentsRequest request) => { })
            .Produces<List<StudentShortInfo>>(StatusCodes.Status200OK)
            .Produces<string>(StatusCodes.Status404NotFound)
            .WithTags(studentTag)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Soft delete students";
                operation.Description = "Soft delete students";

                return operation;
            });

        builder
            .MapPatch("api/students/drop", ([FromBody] DropOutStudentsRequest request) => { })
            .Produces<List<StudentShortInfo>>(StatusCodes.Status200OK)
            .Produces<string>(StatusCodes.Status404NotFound)
            .WithTags(studentTag)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Drop out students";
                operation.Description = "Drop out students";

                operation.Responses.Add(
                    StatusCodes.Status422UnprocessableEntity.ToString(),
                    new OpenApiResponse
                    {
                        Description = "Unprocessable Entity\n\nCannot drop out students",
                        Content = new Dictionary<string, OpenApiMediaType>
                        {
                            ["application/json"] = new OpenApiMediaType
                            {
                                Schema = new OpenApiSchema { Type = "string" },
                            },
                        },
                    }
                );

                return operation;
            });

        builder
            .MapPut("api/student", ([FromBody] EditStudentRequest request) => { })
            .Produces<StudentShortInfo>(StatusCodes.Status200OK)
            .Produces<ValidationError>(StatusCodes.Status400BadRequest)
            .WithTags(studentTag)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Edit student";
                operation.Description = "Edit student";

                operation.RequestBody.Description =
                    "If you set the droppedOutAt to null, then you can cancel the deduction";

                operation.Responses.Add(
                    StatusCodes.Status404NotFound.ToString(),
                    new OpenApiResponse
                    {
                        Description = "Not Found\n\nStudent or group not found",
                        Content = new Dictionary<string, OpenApiMediaType>
                        {
                            ["application/json"] = new OpenApiMediaType
                            {
                                Schema = new OpenApiSchema { Type = "string" },
                            },
                        },
                    }
                );

                return operation;
            });

        return builder;
    }
}
