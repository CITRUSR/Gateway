using Gateway.Data.Dtos.ScheduleService;

namespace Gateway.Endpoints.ScheduleService.Class.Responses;

public record TeacherColorClasses(ColorDto Color, List<TeacherClassDetail> Classes)
    : ColorClassesBase(Color);
