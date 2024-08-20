namespace Gateway.Data.Dtos;

public record SpecialityDto(
    int Id,
    string Name,
    string Abbreviation,
    decimal Cost,
    byte DurationMonths,
    bool IsDeleted
);
