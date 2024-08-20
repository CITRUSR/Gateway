namespace Gateway.Data.Dtos;

public record TeacherDto(
    Guid Id,
    Guid SsoId,
    string FirstName,
    string LastName,
    string? PatronymicName,
    short RoomId,
    DateTime? FiredAt,
    bool IsDeleted
);
