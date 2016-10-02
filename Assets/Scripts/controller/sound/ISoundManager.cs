namespace Assets.Scripts.controller.sound
{
    public interface ISoundManager
    {
        void Init();

        int SoundVolume { get; }

        int MusicVolume { get; }
    }
}
