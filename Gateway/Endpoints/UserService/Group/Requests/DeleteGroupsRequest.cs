using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.UserService.Group.Requests;

public record DeleteGroupsRequest([property: Required] List<int> GroupsId);
