using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.UserService.Speciality.Responses;

public record SpecialityShortInfo(
    [property: Required] int Id,
    [property: Required] [property: MaxLength(256)] string Name
);
