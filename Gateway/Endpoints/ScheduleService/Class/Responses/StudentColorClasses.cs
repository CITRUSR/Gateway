namespace Gateway.Endpoints.ScheduleService.Class.Responses;

public record StudentColorClasses(
    Data.Dtos.ScheduleService.ColorDto Color,
    List<StudentClassDetail> Classes
) : ColorClassesBase(Color);
