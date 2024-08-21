using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.UserService.Group.Responses;

public record GetGroupsResponse([property: Required] int LastPage, List<GroupViewModel> Groups);
