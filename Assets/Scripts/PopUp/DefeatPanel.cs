using NTPackage.UI;
using UnityEngine;
using UnityEngine.UI;
namespace TitleGame
{
    public class DefeatPanel : PopupUI
    {
        //[SerializeField] Button menuButton;
        //[SerializeField] Button replayButton;

        public override void OnUI(object data = null)
        {
            base.OnUI(data);
            //menuButton.onClick.AddListener(MenuButton);
            //replayButton.onClick.AddListener(ReplayButton);
        }
        public void ReplayButton()
        {
            AudioController.PlaySound(AudioController.Sounds.buttonSound);
            if (NetworkSettingsOpener.Instance.CheckInternet() && DataController.instance.dataPlayerController.isRemoveADS == false && DataController.instance.dataPlayerController.numberAdsWWin % 3 == 0)

            {
                if (!AdsManager.instance.IsInterstitialAdReady())
                {
                    Ads();
                    AdsManager.instance.LoadInterstitialAd();
                }
                else
                {
                    AdsManager.instance.ShowInterstitialAd(Ads);
                }
            }
            else
            {
                Ads();
            }
           // Ads();
        }

        public void Ads()
        {
            if (LivesManager.Lives <= 0)
            {
                Debug.Log("sao3");
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
        public void MenuButton()
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