using UnityEngine;
using NTPackage.UI;
using UnityEngine.UI;
using System.Collections;
using TMPro;
namespace Private
{
    public class ResultPanel : PopupUI
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI hightScoreText;

        public override void OnUI(object data = null)
        {
            base.OnUI(data);
            Init();
        }
        public void Init()
        {
            this.scoreText.text = "Score:" + DataController.instance.Point.ToString();
            this.hightScoreText.text = "HighScore:" + DataController.instance.DataPlayerController.HightPoint.ToString();
        }
        public override void OffUI()
        {
            base.OffUI();
            PopupManager.Instance.OnUI(PopupCode.LoadingUI);
            GameManager.instance.ResetGame();
        }
    }
}
