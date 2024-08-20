namespace Gateway.Endpoints.UserService.Speciality.Requests;

public record EditSpecialityRequest(
    int Id,
    string Name,
    string Abbreviation,
    decimal Cost,
    byte DurationMonths,
    bool IsDeleted
);
