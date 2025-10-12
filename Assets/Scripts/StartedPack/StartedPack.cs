using IAP;
using NTPackage.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TitleGame
{

    public class StartedPack : MonoBehaviour
    {
        //[SerializeField, Tooltip("In hours")] int infiniteLifeDuration;

        [Space]

#if MODULE_POWERUPS
        [SerializeField] List<PUType> powerUps;
       // [SerializeField] int powerUpsAmount;
#endif

        //[SerializeField] int coinsAmount;

        [Space]

#if MODULE_POWERUPS
        [SerializeField] TMP_Text powerUpsText;
#endif

        [SerializeField] TMP_Text livesText;
        [SerializeField] TMP_Text coinsText;
        [SerializeField] private TextMeshProUGUI priceText;
        private void Awake()
        {
           // base.Awake();

#if MODULE_POWERUPS
            powerUpsText.text = $"x{Contans.powerUpsAmount}";
#endif

            coinsText.text = $"x{Contans.coinsAmount}";
            //livesText.text = $"{infiniteLifeDuration}hrs";
        }
        public void InitPrice()
        {
            IAPManager.Instance.FetchPrice(Contans.StarterPack, UpdatePriceText);
            IAP.IAPManager.Instance.InitActionSuccess(Contans.StarterPack, OnBuySuccess);
            IAP.IAPManager.Instance.InitActionFail(Contans.StarterPack, OnBuyFail);

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
        //        protected override void ApplyOffer()
        //        {
        //            LivesManager.StartInfiniteLives(infiniteLifeDuration * 60 * 60);

        //#if MODULE_POWERUPS
        //            for (int i = 0; i < powerUps.Count; i++)
        //            {
        //                if (System.Enum.IsDefined(typeof(PUType), powerUps[i]))
        //                {
        //                    var type = powerUps[i];

        //                    PUController.AddPowerUp(type, powerUpsAmount);
        //                }
        //            }
        //#endif

        //            UIIAPStore iapStore = UIController.GetPage<UIIAPStore>();
        //            iapStore.SpawnCurrencyCloud((RectTransform)transform, CurrencyType.Coins, 15, () =>
        //            {
        //                // CurrenciesController.Add(CurrencyType.Coins, coinsAmount);
        //                CurrenciesController.Add(coinsAmount);
        //            });

        //            // AdsManager.DisableForcedAd();
        //        }

        //        protected override void ReapplyOffer()
        //        {
        //            // AdsManager.DisableForcedAd();
        //        }
        public void OneClick()
        {
            //SoundController.instance.AudioButton();
            AudioController.PlaySound(AudioController.Sounds.buttonSound);
            IAP.IAPManager.Instance.OnPurchaseButtonClick(Contans.StarterPack);
        }
        public void OnBuySuccess()
        {
            ApplyOffer();
        }

        public void OnBuyFail()
        {
            PopupManager.Instance.OnUI(PopupCode.NoticePanel);
        }

        public void ApplyOffer()
        {
            for (int i = 0; i < powerUps.Count; i++)
            {
                if (System.Enum.IsDefined(typeof(PUType), powerUps[i]))
                {
                    var type = powerUps[i];

                    PUController.AddPowerUp(type, Contans.powerUpsAmount);
                }
            }
            DataController.instance.dataPlayerController.gold += Contans.coinsAmount;
            DataController.instance.dataPlayerController.isRemoveADS = true;
            DataController.instance.dataPlayerController.isStartedPack = true;
            AdsManager.instance.RemoveAds();
            DataController.instance.SaveData();
            PopupManager.Instance.UpdateDataUI(PopupCode.PopwerUpPurchasePanel);
            UIController.InitText();
            UIController.InitBtnAds();
            this.gameObject.SetActive(false);
        }
    }

}