namespace Gateway.Endpoints.UserService.Speciality.Responses;

public record GetSpecialitiesResponse(int LastPage, List<SpecialityViewModel> Specialities);
