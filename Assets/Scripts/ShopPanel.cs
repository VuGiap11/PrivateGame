using NTPackage.UI;
using System.Collections.Generic;
namespace TitleGame
{
    public class ShopPanel : PopupUI
    {
        public List<SmallMoneyPack> SmallMoneyPacks = new List<SmallMoneyPack>();
        public StartedPack startedPack;
        public override void OnUI(object data = null)
        {
            base.OnUI(data);
            SetData();
        }
        public override void OffUI()
        {
            base.OffUI();
            
        }

        public void SetData()
        {
            if (DataAssets.instance.IapDataCfs.iapDataCfs.Count <= 0) return;
            if (DataAssets.instance.IapDataCfs.iapDataCfs.Count != SmallMoneyPacks.Count) return;
            for (int i = 0; i < DataAssets.instance.IapDataCfs.iapDataCfs.Count; i++)
            {
                SmallMoneyPacks[i].Init(DataAssets.instance.IapDataCfs.iapDataCfs[i]);
            }
        }
        public override void UpdateData(object data = null)
        {
            base.UpdateData(data);
            startedPack.InitPrice();
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
                    AdsManager.instance.LoadRewardedInterstitialAd();
                }
                else
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

