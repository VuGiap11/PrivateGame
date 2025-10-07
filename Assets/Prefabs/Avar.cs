using NTPackage.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace TitleGame
{
    public class Avar : MonoBehaviour
    {
        public int id;
        public Image avar;
        public GameObject icoinOn;
        public void Init(Sprite sprite)
        {
            this.avar.sprite = sprite;
            if (this.id == DataController.instance.dataPlayerController.idAvar)
            {
                icoinOn.SetActive(true);
            }else
            {
                icoinOn.SetActive(false);
            }
        }
        public void OneClick()
        {
           // SoundController.instance.AudioButton();
            DataController.instance.dataPlayerController.idAvar = this.id;
            //HomeController.instance.SetAvar();
            AvarPanel avarPanel = PopupManager.Instance.GetPopupUIByCode(PopupCode.AvatarChangeUI) as AvarPanel;
            avarPanel.SetAvar();        
        }
     
    }
}
