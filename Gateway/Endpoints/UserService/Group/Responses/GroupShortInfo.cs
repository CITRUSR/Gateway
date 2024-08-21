using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.UserService.Group.Responses;

public record GroupShortInfo([property: Required] int Id, [property: Required] string GroupName);
