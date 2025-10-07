using DG.Tweening;
using NTPackage.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TitleGame
{
    public class PowerUpPurchasePanel : PopupUI
    {
        [SerializeField] Image powerUpPurchasePreview;
        [SerializeField] TMP_Text powerUpPurchaseAmountText;
        [SerializeField] TMP_Text powerUpPurchaseDescriptionText;
        [SerializeField] TMP_Text powerUpPurchasePriceText;
        [SerializeField] TMP_Text GoldText;
        [SerializeField] GameObject notiObj;

        public PUSettings settings;

        public override void OnUI(object data = null)
        {
            base.OnUI(data);
            this.notiObj.SetActive(false);
            this.settings = data as PUSettings;
            this.GoldText.text = DataController.instance.dataPlayerController.gold.ToString();
            powerUpPurchasePreview.sprite = settings.Icon;
            powerUpPurchaseDescriptionText.text = settings.Description;
            powerUpPurchasePriceText.text = settings.Price.ToString();
            powerUpPurchaseAmountText.text = string.Format("x{0}", settings.PurchaseAmount);
        }

        public void Buy()
        {
            if (DataController.instance.dataPlayerController.gold <= this.settings.Price)
            {
                OnNoti();
            }else
            {
                AudioController.PlaySound(AudioController.Sounds.buttonSound);
                bool purchaseSuccessful = PUController.PurchasePowerUp(settings.Type);
               // this.GoldText.text = DataController.instance.dataPlayerController.gold.ToString();
                if (purchaseSuccessful)
                    base.OffUI();
            }

        }

        public override void UpdateData(object data = null)
        {
            base.UpdateData(data);
            this.GoldText.text = DataController.instance.dataPlayerController.gold.ToString();
        }
        private void OnNoti()
        {
            this.notiObj.SetActive(true);
            DOVirtual.DelayedCall(1f, ()=> this.notiObj.SetActive(false));
        }
    }
}
