namespace ExampleProject
{
    public interface ISettingsMenuView : IView
    {
        void SetMusicParameter(bool isOn);
        void SetSoundEffectsParameter(bool isOn);
    }
}