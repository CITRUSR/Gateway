using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.UserService.Group.Requests;

public record RecoveryGroupsRequest([property: Required] List<int> GroupsId);
