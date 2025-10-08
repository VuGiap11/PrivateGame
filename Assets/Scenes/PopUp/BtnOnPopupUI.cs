using System.Collections;
using System.Collections.Generic;
using TitleGame;
using UnityEngine;

namespace NTPackage.UI
{
    public class BtnOnPopupUI : MonoBehaviour
    {
        public PopupCode PopupCode;
        public void _OneClick()
        {
            PopupManager.Instance.OnUI(PopupCode);
            AudioController.PlaySound(AudioController.Sounds.buttonSound);
            Debug.Log("PopUpcode" + PopupCode);
        }
    }
}