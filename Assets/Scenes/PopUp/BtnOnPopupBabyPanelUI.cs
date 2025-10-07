
using UnityEngine;
namespace NTPackage.UI
{
    public class BtnOnPopupBabyPanelUI : MonoBehaviour
    {
        public PopupCode PopupCode;
        public void _OneClick()
        {
            //int number = Random.Range(0, 10);
            //if (number <= 5)
            //{
            //    Ads();
            //}
            //else
            //{
            //    if (NetworkSettingsOpener.Instance.CheckInternet() && DataController.instance.dataPlayerController.isRemoveADS == false && DataController.instance.dataPlayerController.numberAds >= 3)

            //    {
            //        if (!AdsManager.instance.IsInterstitialAdReady())
            //        {
            //            Ads();
            //        }
            //        else
            //        {
            //            AdsManager.instance.ShowInterstitialAd(Ads);
            //        }

            //    }
            //    else
            //    {
            //        Ads();
            //    }
            //}

            Ads();

        }

        public void Ads()
        {
            PopupManager.Instance.OnUI(PopupCode);
            Debug.Log("PopUpcode" + PopupCode);
        }
    }
}