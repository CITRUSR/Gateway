using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.UserService.Speciality.Responses;

public record SpecialityViewModel(
    [property: Required] int Id,
    [property: Required] [property: MaxLength(256)] string Name,
    [property: Required] [property: MaxLength(10)] string Abbreviation
);
