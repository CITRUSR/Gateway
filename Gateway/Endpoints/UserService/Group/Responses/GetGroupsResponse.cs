namespace Gateway.Endpoints.UserService.Group.Responses;

public record GetGroupsResponse(int LastPage, List<GroupViewModel> Groups);
