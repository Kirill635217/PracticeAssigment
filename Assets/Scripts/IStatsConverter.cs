public interface IStatsConverter
{
    string ConvertToJson(Stats statsDefault);
    
    Stats ConvertFromJson(string statsJson);
}
