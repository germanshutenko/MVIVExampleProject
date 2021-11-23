using System;

namespace ExampleProject
{
    public interface ISettingsMenuView : IView
    {
        event Action MusicClicked;
        event Action SoundEffectsClicked;
        event Action BackClicked;

        void SetMusicParameter(bool isOn);
        void SetSoundEffectsParameter(bool isOn);
    }
}