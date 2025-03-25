using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Private
{
    [System.Serializable]
    public class HeroBought
    {
        public List<int> Indexs = new() { 0 };
    }
    public class HeroShow : MonoBehaviour
    {
        public int IndexHeroBought;
        public TextMeshProUGUI PriceText;
        public HeroDataCf HeroDataCf;
        public GameObject AvaHero;
        public Transform CharAva;
        public GameObject selecObj;
        public GameObject buyObj;

        public void SetData(HeroDataCf heroDataCf)
        {
            this.HeroDataCf = heroDataCf;
            this.IndexHeroBought = heroDataCf.Index;
            if (this.AvaHero != null) Destroy(this.AvaHero);
            this.PriceText.text = heroDataCf.Price.ToString();

            GameObject avaPreb = DataController.instance.GetHeroUIPrefabByIndex(heroDataCf.Index);
            if (avaPreb != null)
            {
                AvaHero = avaPreb;
                AvaHero.transform.SetParent(this.CharAva);
                AvaHero.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
                AvaHero.transform.localScale = Vector3.one;
            }
            CheckBuyHero();
        }

        public void BuyHero()
        {
            if (DataController.instance.DataPlayerController.gold < HeroDataCf.Price)
            {
                return;
            }
            DataController.instance.DataPlayerController.gold -= HeroDataCf.Price;
            DataController.instance.HeroBought.Indexs.Add(IndexHeroBought);
            DataController.instance.SaveData();
            UIManager.Instance.TextGOLD();
            CheckBuyHero();

        }

        public void SelectHero()
        {
            GameManager.instance.IndexPlayer = HeroDataCf.Index;
            Debug.Log(GameManager.instance.IndexPlayer);
            UIManager.Instance.CLoseShop();
            GameManager.instance.SpawnPlayer(GameManager.instance.IndexPlayer);
        }
        public void CheckBuyHero()
        {
            if (isBought(IndexHeroBought))
            {
                selecObj.SetActive(true);
                buyObj.SetActive(false);

            }
            else
            {
                buyObj.SetActive(true);
                selecObj.SetActive(false);
            }
        }

        bool isBought(int targetNumber)
        {
            foreach (int number in DataController.instance.HeroBought.Indexs)
            {
                if (number == targetNumber)
                {
                    return true;
                }
            }
            return false;
        }
    }

}
