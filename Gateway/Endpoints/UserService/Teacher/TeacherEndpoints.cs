using Gateway.Contracts.UserService;
using Gateway.Data.Dtos;
using Gateway.Data.Enums;
using Gateway.Data.Errors;
using Gateway.Endpoints.UserService.Teacher.Enums;
using Gateway.Endpoints.UserService.Teacher.Requests;
using Gateway.Endpoints.UserService.Teacher.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

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

        builder
            .MapPost(
                "api/teacher",
                async ([FromBody] CreateTeacherRequest request, ITeacherService teacherService) =>
                {
                    var result = await teacherService.CreateTeacher(request);

                    return Results.Created("", result);
                }
            )
            .Produces<TeacherShortInfo>(StatusCodes.Status201Created)
            .Produces<ValidationError>(StatusCodes.Status400BadRequest)
            .WithTags(teacherTag)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Create teacher";
                operation.Description = "Create teacher";

                operation.Responses.Add(
                    StatusCodes.Status404NotFound.ToString(),
                    new OpenApiResponse
                    {
                        Description = "Not Found\n\nRoom not found",
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
            .MapDelete(
                "api/teachers",
                async ([FromBody] DeleteTeachersRequest request, ITeacherService teacherService) =>
                {
                    var result = await teacherService.DeleteTeachers(request);

                    return Results.Ok(result);
                }
            )
            .Produces<List<TeacherShortInfo>>(StatusCodes.Status200OK)
            .Produces<string>(StatusCodes.Status404NotFound)
            .WithTags(teacherTag)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Delete teachers";
                operation.Description = "Delete teachers";

                return operation;
            });

        builder
            .MapDelete("api/teachers/soft", ([FromBody] DeleteTeachersRequest request) => { })
            .Produces<List<TeacherShortInfo>>(StatusCodes.Status200OK)
            .Produces<string>(StatusCodes.Status404NotFound)
            .WithTags(teacherTag)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Soft delete teachers";
                operation.Description = "Soft delete teachers";

                return operation;
            });

        builder
            .MapPatch("api/teachers/recovery", ([FromBody] RecoveryTeachersRequest request) => { })
            .Produces<List<TeacherShortInfo>>(StatusCodes.Status200OK)
            .Produces<string>(StatusCodes.Status404NotFound)
            .WithTags(teacherTag)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Recovery teachers";
                operation.Description = "Recovery teachers";

                return operation;
            });

        builder
            .MapPatch(
                "api/teachers/fire",
                async ([FromBody] FireTeachersRequest request, ITeacherService teacherService) =>
                {
                    var result = await teacherService.FireTeachers(request);

                    return Results.Ok(result);
                }
            )
            .Produces<List<TeacherShortInfo>>(StatusCodes.Status200OK)
            .Produces<string>(StatusCodes.Status404NotFound)
            .WithTags(teacherTag)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Fire teachers";
                operation.Description = "Fire teachers";

                operation.Responses.Add(
                    StatusCodes.Status422UnprocessableEntity.ToString(),
                    new OpenApiResponse
                    {
                        Description = "Unprocessable Entity\n\nCannot fire teachers",
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
            .MapPut(
                "api/teacher",
                async ([FromBody] EditTeacherRequest request, ITeacherService teacherService) =>
                {
                    var result = await teacherService.EditTeacher(request);

                    return Results.Ok(result);
                }
            )
            .Produces<TeacherShortInfo>(StatusCodes.Status200OK)
            .Produces<ValidationError>(StatusCodes.Status400BadRequest)
            .WithTags(teacherTag)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Edit teacher";
                operation.Description = "Edit teacher";

                operation.RequestBody.Description =
                    "If you set the FiredAt to null, then you can cancel the fired";

                operation.Responses.Add(
                    StatusCodes.Status404NotFound.ToString(),
                    new OpenApiResponse
                    {
                        Description = "Not Found\n\nTeacher or room not found",
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
