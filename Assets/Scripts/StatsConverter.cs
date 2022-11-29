using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

public class StatsConverter : IStatsConverter
{
    public string ConvertToJson(StatsCapture.Stats stats) => JsonConvert.SerializeObject(stats);

    public StatsCapture.Stats ConvertFromJson(string statsJson) => JsonConvert.DeserializeObject<StatsCapture.Stats>(statsJson);
}
