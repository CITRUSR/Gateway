using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gateway.Data.Dtos;

public record SpecialityDto(
    [property: Required] int Id,
    [property: Required] [property: MaxLength(256)] string Name,
    [property: Required] [property: MaxLength(10)] string Abbreviation,
    [property: Required] [property: DefaultValue(0)] decimal Cost,
    [property: Required] [property: Range(1, byte.MaxValue)] byte DurationMonths,
    [property: Required] bool IsDeleted
);
