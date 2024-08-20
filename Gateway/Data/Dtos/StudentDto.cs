namespace Gateway.Data.Dtos;

public record StudentDto(
    Guid Id,
    Guid SsoId,
    string FirstName,
    string LastName,
    string? PatronymicName,
    int GroupId,
    DateTime? DroppedOutAt,
    bool IsDeleted
);
