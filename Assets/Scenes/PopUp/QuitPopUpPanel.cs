using NTPackage.UI;
using UnityEngine;
using UnityEngine.UIElements;

namespace TitleGame
{

    public class QuitPopUpPanel : PopupUI
    {
        public override void OnUI(object data = null)
        {
            base.OnUI(data);
        }

        public override void OffUI()
        {
            base.OffUI();
        }

        public void ClaimQuit()
        {
            AudioController.PlaySound(AudioController.Sounds.buttonSound);
            if (LivesManager.IsMaxLives)
                LivesManager.RemoveLife();

            base.OffUI();
            UIController.HidePage<UIGame>();

            GameController.ReturnToMenu();

        }
    }
}
