using System;
using UnityEngine;

namespace NTPackage.UI
{
    public class PopupCodeParser
    {
        public static PopupCode FromString(string name)
        {
            //name = name.ToLower();W
            return (PopupCode)Enum.Parse(typeof(PopupCode), name);
        }
    }

    [System.Serializable]
    public enum PopupCode
    {
        Unknown = 0,
        LoadingBgUI,
        AddLivesPanel,
        QuitPopUpPanel,
        PopwerUpPurchasePanel,
        VictoryPanel,
        DefeatPanel,
        soundSetting,
        AvatarChangeUI,
        NameChangeUI,
        ShopPanel,
        NoInternet,
        NoAds,
        NoticePanel,
        ResultIAP,
        RomoveAds,
    }
}
