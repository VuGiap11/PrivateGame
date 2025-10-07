using NTPackage.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Private
{
    public class HeroShopManager : PopupUI
    {
        public HeroShow heroShowPreb;
        public Transform Holder;
        public List<HeroShow> heroShows;


        public override void OnUI(object data = null)
        {
            base.OnUI(data);
            OnUI();
        }
        public void OnUI()
        {
            Debug.Log("chạy hàm sinh ra vatar");
            //if (gameObject.activeSelf) return;
            this.heroShows.Clear();
            foreach (Transform item in Holder)
            {
                item.gameObject.SetActive(false);
                if (item.TryGetComponent<HeroShow>(out HeroShow show)) { this.heroShows.Add(show); }
            }
            for (int i = 0; i < DataController.instance.HeroDataCfs.HeroDatas.Count; i++)
            {
                HeroShow heroShow;
                try
                {
                    heroShow = heroShows[i];
                }
                catch (Exception e)
                {
                    heroShow = Instantiate(heroShowPreb);
                    this.heroShows.Add(heroShow);
                }
                heroShow.gameObject.SetActive(true);
                heroShow.SetData(DataController.instance.HeroDataCfs.HeroDatas[i]);
                heroShow.transform.SetParent(this.Holder);
                heroShow.transform.localScale = Vector3.one;
            }
        }
    }
}

