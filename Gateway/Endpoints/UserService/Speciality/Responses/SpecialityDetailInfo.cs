using System.Diagnostics.CodeAnalysis;

namespace Gateway.Endpoints.UserService.Speciality.Responses;

public record SpecialityDetailInfo(
    int Id,
    string Name,
    string Abbreviation,
    decimal Cost,
    byte DurationMonths,
    bool IsDeleted
);
