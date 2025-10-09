using DG.Tweening;
using NTPackage.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TitleGame
{
    public class NoticePanel : PopupUI
    {
        public override void OnUI(object data = null)
        {
            base.OnUI(data);
            DOVirtual.DelayedCall(1.7f, delegate
            {
                OffUI();
            });
        }
    }
}
