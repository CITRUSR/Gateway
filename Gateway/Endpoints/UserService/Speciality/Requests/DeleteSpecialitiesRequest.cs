using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.UserService.Speciality.Requests;

public record DeleteSpecialitiesRequest([property: Required] List<int> SpecialitiesId);
