namespace Gateway.Endpoints.UserService.Speciality.Requests;

public record CreateSpecialityRequest(
    string Name,
    string Abbreavation,
    decimal Cost,
    byte DurationMonths
);
