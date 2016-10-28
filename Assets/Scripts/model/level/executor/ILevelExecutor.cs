namespace Assets.Scripts.model.level.executor
{
    public interface ILevelExecutor
    {
        void ExecuteLevel(LevelConfigModel level);

        void Clear();
    }
}
