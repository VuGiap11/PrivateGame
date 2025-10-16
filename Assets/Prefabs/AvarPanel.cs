using NTPackage.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TitleGame
{
    public class AvarPanel : PopupUI
    {
        //[SerializeField] Transform holder;
        public List<Avar> listsAva;


        public override void OnUI(object data = null)
        {
            base.OnUI(data);
            this.SetAvar();
        }
        public void ChangeAvar()
        {
            //SoundController.instance.AudioButton();
            AudioController.PlaySound(AudioController.Sounds.buttonSound);
            int number = Random.Range(0, 10);
            if (number <= 7)
            {
                ClaimAva();
            }
            else
            {
                if (NetworkSettingsOpener.Instance.CheckInternet() && DataController.instance.dataPlayerController.isRemoveADS == false&& DataController.instance.dataPlayerController.numberAds >=2)

                {
                    if (!AdsManager.instance.IsInterstitialAdReady())
                    {
                        ClaimAva();
                        AdsManager.instance.LoadInterstitialAd();
                    }
                    else
                    {
                        AdsManager.instance.ShowInterstitialAd(ClaimAva);
                    }

                }
                else
                {
                    ClaimAva();
                }
            }
           // ClaimAva();
        }

        public void ClaimAva()
        {
            DataController.instance.SaveData();
            InforUser inforUser = PopupManager.Instance.GetPopupUIByCode(PopupCode.NameChangeUI) as InforUser;
            if (inforUser != null)
            {
                //inforUser.OnUI();
                inforUser.SetAvatar();
            }
            else
            {
                Debug.Log("hopepanel is null");
            }
            this.OffUI();
        }


        public void SetAvar()
        {
            if (this.listsAva.Count != DataAssets.instance.imageAvar.Count) return;
            for (int i = 0; i < this.listsAva.Count; i++)
            {
                this.listsAva[i].Init(DataAssets.instance.imageAvar[i]);
            }
        }
    }
}