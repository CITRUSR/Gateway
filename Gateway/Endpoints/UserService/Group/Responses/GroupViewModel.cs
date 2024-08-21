using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.UserService.Group.Responses;

public record GroupViewModel(
    [property: Required] int Id,
    [property: Required] int StudentCount,
    [property: Required] string CuratorFirstName,
    [property: Required] string CuratorLastName,
    string? CuratorPatronymicName,
    [property: Required] string GroupName
);
