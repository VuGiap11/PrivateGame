using NTPackage.UI;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace Private
{
    public class PopUpLoadingUI : PopupUI
    {
        [SerializeField] ItemLoading itemLoading;
        [SerializeField] private Image levelBarSprite;
        public float fillTime = 2f;
        private float targetFill = 1f;
        public override void OnUI(object data = null)
        {
            base.OnUI(data);
            StartLoadingBgUI();
        }
        public void StartLoadingBgUI()
        {
            //SceneManager.LoadScene(this.nameScene);
            itemLoading.StartAnimLoading();
            if (loading != null)
            {
                StopCoroutine(loading);
            }
            loading = StartCoroutine(FillBarSmoothly());
        }
        Coroutine loading;
        private IEnumerator FillBarSmoothly()
        {
            //float startFill = levelBarSprite.fillAmount;
            float startFill = 0f;
            float elapsedTime = 0f;

            while (elapsedTime < fillTime)
            {
                levelBarSprite.fillAmount = Mathf.Lerp(startFill, targetFill, elapsedTime / fillTime);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            levelBarSprite.fillAmount = targetFill;
            StopAnim();
            this.OffUI();
         
        }
        private void StopAnim()
        {
            if (loading != null)
            {
                StopCoroutine(loading);
            }
            itemLoading.StopAnimLoading();    
        }
    }
}