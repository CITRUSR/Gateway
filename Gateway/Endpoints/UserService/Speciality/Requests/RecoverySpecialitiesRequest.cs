using System.ComponentModel.DataAnnotations;

namespace Gateway.Endpoints.UserService.Speciality.Requests;

public record RecoverySpecialitiesRequest([property: Required] List<int> SpecialitiesId);
