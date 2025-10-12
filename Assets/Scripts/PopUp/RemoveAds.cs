using DG.Tweening;
using IAP;
using NTPackage.UI;
using TitleGame.TitleGame;
using TMPro;
using UnityEngine;
namespace TitleGame
{

    public class RemoveAds : PopupUI
    {
        public TextMeshProUGUI priceText;
        public override void OnUI(object data = null)
        {
            base.OnUI(data);
            IAPManager.Instance.FetchPrice(Contans.RemoveADS, UpdatePriceText);
            IAP.IAPManager.Instance.InitActionSuccess(Contans.RemoveADS, OnBuySuccess);
            IAP.IAPManager.Instance.InitActionFail(Contans.RemoveADS, OnBuyFail);
        }
        public override void OffUI()
        {
            base.OffUI();
        }

        private void UpdatePriceText(float price)
        {
            if (price >= 0)
            {
                // priceText.text = $"US$: {price}";
                priceText.text = price.ToString();
            }

            else
            {
                priceText.text = "Price not available";
            }
        }
        public void OneClick()
        {
            AudioController.PlaySound(AudioController.Sounds.buttonSound);
            IAP.IAPManager.Instance.OnPurchaseButtonClick(Contans.RemoveADS);
        }
        public void OnBuySuccess()
        {
            Debug.Log("Mua thành công");
            OffUI();
            DataController.instance.dataPlayerController.gold += 10000;
            DataController.instance.dataPlayerController.isRemoveADS = true;
            DataController.instance.SaveData();
            AdsManager.instance.RemoveAds();
        }

        public void OnBuyFail()
        {
            PopupManager.Instance.OnUI(PopupCode.NoticePanel);
        }
    }

}