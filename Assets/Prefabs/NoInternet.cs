using DG.Tweening;
using NTPackage.UI;
namespace TitleGame
{
    public class NoInternet : PopupUI
    {
        public override void OnUI(object data = null)
        {
            base.OnUI(data);
            DOVirtual.DelayedCall(2f, () => OffUI());
        }
        public override void OffUI()
        {
            base.OffUI();
        }
    }
}

