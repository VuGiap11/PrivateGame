using NTPackage.UI;
using System;
using TMPro;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace TitleGame
{
    public class LivesIndicator : MonoBehaviour
    {
        [Space]
        [SerializeField] TextMeshProUGUI livesCountText;
        [SerializeField] Image infinityImage;
        [SerializeField] TextMeshProUGUI durationText;

        [Space]
        [SerializeField] Button addButton;
        [SerializeField] AddLivesPanel addLivesPanel;

        private LivesData Data { get; set; }

        private bool isInitialised;

        public void Init(LivesData data)
        {
            if (isInitialised) return;
            
            Data = data;

            //if(addLivesPanel != null)
            //{
            //    addButton.gameObject.SetActive(true);
            //    //addButton.onClick.AddListener(() => addLivesPanel.Show());
            //    addButton.onClick.AddListener(() => PopupManager.Instance.OnUI(PopupCode.AddLivesPanel));
            //} else
            //{
            //    addButton.gameObject.SetActive(false);
            //}
            if (LivesManager.Lives >= 5)
            {
                addButton.gameObject.SetActive(false);
                Debug.Log("gggggggggggggggggggg" + LivesManager.Lives);

            }
            else
            {
                Debug.Log("aandbdbdd" +  LivesManager.Lives);
                addButton.gameObject.SetActive(true);
            }
            addButton.onClick.AddListener(() => PopupManager.Instance.OnUI(PopupCode.AddLivesPanel));
            isInitialised = true;
        }

        public void SetInfinite(bool isInfinite)
        {
            infinityImage.gameObject.SetActive(isInfinite);
            livesCountText.gameObject.SetActive(!isInfinite);
        }

        public void SetLivesCount(int count)
        {
            if (!isInitialised) return;

            livesCountText.text = count.ToString();

            //addButton.gameObject.SetActive(count != Contans.maxLivesCount && addLivesPanel != null);
            addButton.gameObject.SetActive(count != Contans.maxLivesCount);
            if (count == Contans.maxLivesCount)
            {
                FullText();
            }
        }

        public void SetDuration(TimeSpan duration) 
        {
            if (!isInitialised) return;

            if (duration >= TimeSpan.FromHours(1))
            {
                durationText.text = string.Format(Data.longTimespanFormat, duration);
            }
            else
            {
                durationText.text = string.Format(Data.timespanFormat, duration);
            }

            SetTextSize(!addButton.gameObject.activeSelf);
        }

        public void FullText()
        {
            if (!isInitialised) return;

            durationText.text = Data.fullText;

            SetTextSize(true);
        }

        private void SetTextSize(bool fullPanel)
        {
            if(fullPanel)
            {
                durationText.rectTransform.offsetMin = new Vector2(70, 0);
                durationText.rectTransform.offsetMax = new Vector2(-38, 0);
            }
            else
            {
                durationText.rectTransform.offsetMin = new Vector2(95, 0);
                durationText.rectTransform.offsetMax = new Vector2(-100, 0);
            }
        }

        private void OnEnable()
        {
            LivesManager.AddIndicator(this);
        }

        private void OnDisable()
        {
            LivesManager.RemoveIndicator(this);
        }
    }
}