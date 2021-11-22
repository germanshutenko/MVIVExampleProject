using UnityEngine.UI;

namespace ExampleProject
{
    public class GameHUDView : BaseView, IGameHUDView
    {
        public Image HPProgressBar;
        public Image ManaProgressBar;
        public Text TimeValueText;

        public void SetHP(float value)
        {
            HPProgressBar.fillAmount = value;
        }

        public void SetMana(float value)
        {
            ManaProgressBar.fillAmount = value;
        }

        public void SetTime(int value)
        {
            TimeValueText.text = value.ToString();
        }
    }
}