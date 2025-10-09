using NTPackage.UI;
using Unity.Jobs;
using UnityEngine;
namespace TitleGame
{
    public class ShopManager : PopupUI
    {
        public override void OnUI(object data = null)
        {
            base.OnUI(data);
        }
        public override void OffUI()
        {
            base.OffUI();
        }
        public void AddGoldFromAds()
        {
            if (!NetworkSettingsOpener.Instance.CheckInternet())
            {
                PopupManager.Instance.OnUI(PopupCode.NoInternet);
            }else
            {
                if (!AdsManager.instance.IsRewardedInterstitialAdReady())
                {
                    PopupManager.Instance.OnUI(PopupCode.NoAds);
                }else
                {
                    AdsManager.instance.ShowRewardedInterstitialAd(AdsGold);
                }
            }
        }

        public void AdsGold()
        {

            DataController.instance.dataPlayerController.gold += 100;
            DataController.instance.SaveData();
            PopupManager.Instance.UpdateDataUI(PopupCode.PopwerUpPurchasePanel);
            UIController.InitText();
            // UIMainMenu.coinsPanel.Initialise();
            //base.OffUI();
        }
    }
}

