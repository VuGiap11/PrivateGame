using DG.Tweening;
using NTPackage.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
namespace TitleGame
{

    public class VictoryPanel : PopupUI
    {
        [SerializeField] Button multiplyRewardButton;
        [SerializeField] Button homeButton;
        [SerializeField] Button nextLevelButton;
        [SerializeField] TextMeshProUGUI rewardAmountText;
        private int currentReward;


        public override void OnUI(object data = null)
        {
            base.OnUI(data);
            currentReward = LevelController.CurrentReward;
            multiplyRewardButton.onClick.AddListener(MultiplyRewardButton);
            homeButton.onClick.AddListener(HomeButton);
            nextLevelButton.onClick.AddListener(NextLevelButton);
            multiplyRewardButton.gameObject.SetActive(false);
            homeButton.interactable = false;
            nextLevelButton.interactable = false;
            DOVirtual.DelayedCall(0.5f, () => Init());
        }
        public void MultiplyRewardButton()
        {
            AudioController.PlaySound(AudioController.Sounds.buttonSound);
            homeButton.interactable = false;
            nextLevelButton.interactable = false;
            int rewardMult = 3;
            multiplyRewardButton.interactable = false;
            DOVirtual.DelayedCall(0.5f, () => InitText(rewardMult));
            //ShowRewardLabel(currentReward * rewardMult, false, 0.3f, delegate
            //{
            //    FloatingCloud.SpawnCurrency(coinsHash, rewardLabel.RectTransform, coinsPanelScalable.RectTransform, 10, "", () =>
            //    {
            //        CurrenciesController.Add(currentReward * rewardMult);
            //        this.coinsPanelUI.SetTextGold();
            //        homeButton.interactable = true;
            //        nextLevelButton.interactable = true;
            //    });
            //});
        }
        public void Init()
        {
            CurrenciesController.Add(currentReward);

            homeButton.interactable = true;
            nextLevelButton.interactable = true;
            multiplyRewardButton.gameObject.SetActive(true);
            multiplyRewardButton.interactable = true;
            SetText(currentReward);
        }
        public void InitText(int rewardMult)
        {
            CurrenciesController.Add(currentReward * rewardMult);
            ///this.coinsPanelUI.SetTextGold();
            homeButton.interactable = true;
            nextLevelButton.interactable = true;
            multiplyRewardButton.interactable = false;
            multiplyRewardButton.gameObject.SetActive(false);
            SetText(currentReward * rewardMult);
        }

        private void SetText(int number)
        {
            this.rewardAmountText.text ="+"+ number.ToString();
        }
        public void HomeButton()
        {
            AudioController.PlaySound(AudioController.Sounds.buttonSound);

            //UIController.HidePage<UIComplete>(() =>
            //{
            //    GameController.ReturnToMenu();
            //});
            UIController.HidePage<UIGame>();
            GameController.ReturnToMenu();
            LivesManager.AddLife();
            base.OffUI();
           
        }

        public void NextLevelButton()
        {
            AudioController.PlaySound(AudioController.Sounds.buttonSound);

            //UIController.HidePage<UIComplete>(() =>
            //{
            //    GameController.LoadNextLevel();
            //});
            UIController.HidePage<UIGame>();
            GameController.LoadNextLevel();
            base.OffUI();

        }
    }
}