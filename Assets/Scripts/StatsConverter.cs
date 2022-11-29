using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

public class StatsConverter : IStatsConverter
{
    public string ConvertToJason(StatsCapture.Stats stats) => JsonConvert.SerializeObject(stats);

    public StatsCapture.Stats ConvertFromJason(string statsJson) => JsonConvert.DeserializeObject<StatsCapture.Stats>(statsJson);
}
