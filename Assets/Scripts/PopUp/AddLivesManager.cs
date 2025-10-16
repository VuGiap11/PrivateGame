using NTPackage.UI;
using TMPro;
using Unity.Jobs;
using UnityEngine;

namespace TitleGame
{
    public class AddLivesManager : PopupUI
    {
        [SerializeField] TMP_Text livesAmountText;
        [SerializeField] TMP_Text timeText;
        [SerializeField] GameObject buttonFill;

        public void Refill()
        {
            if (!NetworkSettingsOpener.Instance.CheckInternet())
            {
                PopupManager.Instance.OnUI(PopupCode.NoInternet);
            }
            else
            {
                if (!AdsManager.instance.IsRewardedInterstitialAdReady())
                {
                    PopupManager.Instance.OnUI(PopupCode.NoAds);
                    AdsManager.instance.LoadRewardedInterstitialAd();
                }
                else
                {
                    AdsManager.instance.ShowRewardedInterstitialAd(Ads);
                }
            }

        }

        private void Ads()
        {
            AudioController.PlaySound(AudioController.Sounds.buttonSound);
            LivesManager.AddLife();
            if (LivesManager.Lives >= 5)
            {
                buttonFill.SetActive(false);
                base.OffUI();
            }
            else
            {
                buttonFill.SetActive(true);
            }
            //if (lifeRecievedAudio != null)
            //    AudioController.PlaySound(lifeRecievedAudio);
        }
        public override void OnUI(object data = null)
        {
            base.OnUI(data);
            SetLivesCount(LivesManager.Lives);

            if (LivesManager.Lives >= 5)
            {
                buttonFill.SetActive(false);
            }else
            {
                buttonFill.SetActive(true);
            }
        }
        public void SetLivesCount(int count)
        {
            livesAmountText.text = count.ToString();
        }

        public override void UpdateData(object data = null)
        {
            base.UpdateData(data);
            SetLivesCount(LivesManager.Lives);

        }
        public void SetTime(string time)
        {
            timeText.text = time;
        }
        [ContextMenu("Test")]
        public void Test()
        {
            SetLivesCount(LivesManager.Lives);
        }
    }
}