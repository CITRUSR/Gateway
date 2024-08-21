using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.UserService.Group.Requests;

public record GraduateGroupsRequest([property: Required] List<int> GroupsId);
