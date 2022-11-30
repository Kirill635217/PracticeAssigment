using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

public class StatsConverter : IStatsConverter
{
    public string ConvertToJson(Stats statsDefault) => JsonConvert.SerializeObject(statsDefault);

    public Stats ConvertFromJson(string statsJson) => JsonConvert.DeserializeObject<Stats>(statsJson);
}
