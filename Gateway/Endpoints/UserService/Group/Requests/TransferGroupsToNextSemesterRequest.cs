using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.UserService.Group.Requests;

public record TransferGroupsToNextSemesterRequest([property: Required] List<int> GroupsId);
