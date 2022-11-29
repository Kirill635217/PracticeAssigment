public interface IStatsConverter
{
    string ConvertToJason(StatsCapture.Stats stats);
    StatsCapture.Stats ConvertFromJason(string statsJson);
}
