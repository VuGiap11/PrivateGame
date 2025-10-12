using NTPackage.UI;
using TitleGame.TitleGame;
using TMPro;
using UnityEngine;
namespace TitleGame
{

    public class SmallMoneyPack : MonoBehaviour
    {
        public TextMeshProUGUI goldText;
        public TextMeshProUGUI priceText;
        public IapDataCf IapDataCf;

        public void Init(IapDataCf IapDataCf)
        {
            this.IapDataCf = IapDataCf;
            this.goldText.text = "x"+this.IapDataCf.Coin.ToString();
            IAP.IAPManager.Instance.FetchPrice(this.IapDataCf.Id, UpdatePriceText);
            IAP.IAPManager.Instance.InitActionSuccess(this.IapDataCf.Id, OnBuySuccess);
            IAP.IAPManager.Instance.InitActionFail(this.IapDataCf.Id, OnBuyFail);
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
        //private void UpdatePriceText(string price)
        //{
        //    priceText.text = price.ToString();
        //    Debug.Log("price" + price);
        //    //if (price != null)
        //    //{
        //    //    // priceText.text = $"US$: {price}";
        //    //    priceText.text = price;

        //    //}

        //    //else
        //    //{
        //    //    priceText.text = "Price not available";
        //    //}
        //}
        public void OneClick()
        {
            AudioController.PlaySound(AudioController.Sounds.buttonSound);
            IAP.IAPManager.Instance.OnPurchaseButtonClick(this.IapDataCf.Id);
        }
        public void OnBuySuccess()
        {
            Debug.Log("Mua thành công");
            DataController.instance.dataPlayerController.gold += this.IapDataCf.Coin;
            DataController.instance.SaveData();
            // HomeController.instance.InitText();
            UIController.InitText();
            PopupManager.Instance.OnUI(PopupCode.ResultIAP);
        }
        public void OnBuyFail()
        {
            //this.noticeObj.SetActive(true);
            //DOVirtual.DelayedCall(1f, delegate
            //{
            //    this.noticeObj.SetActive(false);
            //});
            //ShopIAPPanel ShopIAPPanel = PopupManager.Instance.GetPopupUIByCode(PopupCode.ShopIAPPanel) as ShopIAPPanel;
            //ShopIAPPanel.OnNotice();
            PopupManager.Instance.OnUI(PopupCode.NoticePanel);
        }
    }

}