using System.ComponentModel.DataAnnotations;
using Gateway.Data.Dtos.ScheduleService;

namespace Gateway.Endpoints.ScheduleService.Room.Responses;

public record GetRoomsResponse(List<RoomDto> Rooms, [property: Required()] int LastPage);
