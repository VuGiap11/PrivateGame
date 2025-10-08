using NTPackage.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TitleGame
{

    public class InforUser : PopupUI
    {
        public TMP_InputField inputFieldName;
        public Image avatar;
        public override void OnUI(object data = null)
        {
            base.OnUI(data);
            Init();
        }
        public void Init()
        {
            this.inputFieldName.text = DataController.instance.dataPlayerController.namePlayer;
            this.avatar.sprite = DataAssets.instance.imageAvar[DataController.instance.dataPlayerController.idAvar];
        }

        public void ChangeName()
        {

            //SoundController.instance.AudioButton();
            //int number = Random.Range(0, 10);
            //if (number <= 7)
            //{
            //    SetName();
            //}else
            //{
            //    if (NetworkSettingsOpener.Instance.CheckInternet() && DataController.instance.dataPlayerController.isRemoveADS == false && DataController.instance.dataPlayerController.numberAds >= 3)

            //    {
            //        if (!AdsManager.instance.IsInterstitialAdReady())
            //        {
            //            SetName();
            //        }
            //        else
            //        {
            //            AdsManager.instance.ShowInterstitialAd(SetName);
            //        }

            //    }
            //    else
            //    {
            //        SetName();
            //    }
            //}
            SetName();
        }

        public void SetName()
        {
            DataController.instance.dataPlayerController.namePlayer = this.inputFieldName.text;
            if (string.IsNullOrEmpty(DataController.instance.dataPlayerController.namePlayer))
            {
                DataController.instance.dataPlayerController.namePlayer = "BabyThree";
            }
            DataController.instance.SaveData();
            this.OffUI();
        }

        public void ChangeAvar()
        {
            // SoundController.instance.AudioButton();
            AudioController.PlaySound(AudioController.Sounds.buttonSound);
            AvarPanel avarPanel = PopupManager.Instance.GetPopupUIByCode(PopupCode.AvatarChangeUI) as AvarPanel;
            if (avarPanel != null)
            {
                avarPanel.OnUI();
            }
            else
            {
                Debug.Log("hopepanel is null");
            }
        }

        public void SetAvatar()
        {
            this.avatar.sprite = DataAssets.instance.imageAvar[DataController.instance.dataPlayerController.idAvar];
            //GameController.avartarPlayer.sprite = DataAssets.instance.imageAvar[DataController.instance.dataPlayerController.idAvar];
            GameController.SetAvar();
        }
    }

}