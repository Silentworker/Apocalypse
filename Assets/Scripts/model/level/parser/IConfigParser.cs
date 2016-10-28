namespace Assets.Scripts.model.level.parser
{
    public interface IConfigParser
    {
        LevelConfigModel GetLevel(int id);
    }
}
