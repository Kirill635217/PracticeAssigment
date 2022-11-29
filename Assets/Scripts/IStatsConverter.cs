public interface IStatsConverter
{
    string ConvertToJson(StatsCapture.Stats stats);
    StatsCapture.Stats ConvertFromJson(string statsJson);
}
