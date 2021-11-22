using UnityEngine;

namespace ExampleProject
{
    public class GameSettings : IGameSettings
    {
        private const string IsMusicOnKey = "IsMusicOn";
        private const string IsSoundEffectsOnKey = "IsSoundEffectsOn";

        public bool IsMusicOn
        {
            get
            {
                var value = PlayerPrefs.GetInt(IsMusicOnKey, 1);
                return value != 0;
            }

            set
            {
                PlayerPrefs.SetInt(IsMusicOnKey, value ? 1 : 0);
            }
        }

        public bool IsSoundEffectsOn
        {
            get
            {
                var value = PlayerPrefs.GetInt(IsSoundEffectsOnKey, 1);
                return value != 0;
            }

            set
            {
                PlayerPrefs.SetInt(IsSoundEffectsOnKey, value ? 1 : 0);
            }
        }
    }
}