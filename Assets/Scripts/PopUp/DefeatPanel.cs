using NTPackage.UI;
using UnityEngine;
using UnityEngine.UI;
namespace TitleGame
{
    public class DefeatPanel : PopupUI
    {
        [SerializeField] Button menuButton;
        [SerializeField] Button replayButton;

        public override void OnUI(object data = null)
        {
            base.OnUI(data);
            menuButton.onClick.AddListener(MenuButton);
            replayButton.onClick.AddListener(ReplayButton);
        }
        private void ReplayButton()
        {
            AudioController.PlaySound(AudioController.Sounds.buttonSound);


            if (LivesManager.Lives <= 0)
            {
   
                PopupManager.Instance.OnUI(PopupCode.AddLivesPanel);
                return;
            }
            else
            {
                // addLivesPanel.Show();
                LivesManager.RemoveLife();

                //UIController.HidePage<UIGameOver>();
                base.OffUI();

                GameController.ReplayLevel();
            }
        }

        private void MenuButton()
        {
            AudioController.PlaySound(AudioController.Sounds.buttonSound);
            base.OffUI();
            //UIController.HidePage<UIGameOver>(() =>
            //{
            //    GameController.ReturnToMenu();
            //});
            UIController.HidePage<UIGame>();
            GameController.ReturnToMenu();
        }
    }

}