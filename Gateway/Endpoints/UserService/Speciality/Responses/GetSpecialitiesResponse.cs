using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.UserService.Speciality.Responses;

public record GetSpecialitiesResponse(
    [property: Required] int LastPage,
    List<SpecialityViewModel> Specialities
);
