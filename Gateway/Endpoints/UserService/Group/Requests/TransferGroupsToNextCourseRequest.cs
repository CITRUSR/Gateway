using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.UserService.Group.Requests;

public record TransferGroupsToNextCourseRequest([property: Required] List<int> GroupsId);
