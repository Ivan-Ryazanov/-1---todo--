using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace WebApplication2.Controllers;

// [HttpGet] Ч "ѕолучить" Ч используетс€ дл€ получени€ данных
// [HttpPost] Ч "ќтправить" Ч обычно дл€ создани€ новых данных
// [HttpPut] Ч "ќбновить" Ч дл€ изменени€ существующих данных
// [HttpDelete] Ч "”далить" Ч дл€ удалени€ данных
// [Route] Ч "ћаршрут" Ч путь, по которому вызываетс€ метод

[ApiController]
[Route("api/missions")]
public partial class Missions : ControllerBase
{
    private readonly static List<Mission> missions = new List<Mission>();

    [HttpGet] // ћетод дл€ возврата списка задач с короткой инфой
    public List<MissionShort> GetListFoShortMissions()
    {
        List<MissionShort> ListForShortMission = missions.Select(mission => new MissionShort()
        {
            Id = mission.Id,
            Name = mission.Name,
            Deadline = mission.Deadline,
            IsCompleted = mission.IsCompleted
        }).ToList();
        return ListForShortMission;
    }

    [HttpGet("{id}")] // ћетод дл€ возврата задачи с полной инфой
    public Mission GetLongMission([FromRoute] Guid id)
    {
        var FullMissionsInfo = missions.Where(missions => missions.Id == id).FirstOrDefault();
        return FullMissionsInfo;
    }


    [HttpPost] // ћетод создани€ задачи
    public Guid CreateMission([FromBody] MissionCreateDto request)
    {
        var id = Guid.NewGuid();
        missions.Add(new Mission()
        {
            Name = request.Name,
            Deadline = request.Deadline,
            Description = request.Description
        });
        return id;
    }


    [HttpPut] // ћетод дл€ обновлени€ задачи
    public void UpdateMission([FromRoute] Guid id, [FromBody] MissionCreateDto request)
    {
        Mission? mission = missions.Where(mission => mission.Id == id).FirstOrDefault();

        if (mission != null)
        {
            mission.Name = request.Name;
            mission.Deadline = request.Deadline;
            mission.Description = request.Description;
        }
    }

    [HttpDelete("{id}")] // ћетод дл€ удалени€ задачи
    public void DeleteMission([FromRoute] Guid id)
    {
        Mission? mission = missions.Where(mission => mission.Id == id).FirstOrDefault();
        if (mission != null)
        {
            missions.Remove(mission);
        }
    }
}