using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace Private
{
    public class DataPlayerController
    {
        public float gold;
        public float HightPoint;
        public float Highdistance;
        public DataPlayerController(float gold, float Hightpoint, float Highdistance)
        {
            this.gold = gold;
            this.HightPoint = Hightpoint;
            this.Highdistance = Highdistance;
        }
    }
    [System.Serializable]
    public class HeroDataCfs
    {
        public List<HeroDataCf> HeroDatas;
    }

    [System.Serializable]
    public class HeroDataCf
    {
        public int Index;
        public int Price;
    }
    [System.Serializable]
    public class HeroBought
    {
        public List<int> Indexs = new() { 0 };
    }

    public class DataController : MonoBehaviour
    {
        public static DataController instance;
        public DataPlayerController DataPlayerController;
        public TextAsset HeroDatatext;
        public HeroDataCfs HeroDataCfs;
        public HeroBought HeroBought;
        public float Point = 0;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
           // LoadData();
        }

       
        public void LoadData()
        {
            this.HeroDataCfs = JsonUtility.FromJson<HeroDataCfs>(this.HeroDatatext.text);
            string jsonDataPlayerController = PlayerPrefs.GetString("dataPlayerController");
            if (!string.IsNullOrEmpty(jsonDataPlayerController))
            {
                DataPlayerController = JsonUtility.FromJson<DataPlayerController>(jsonDataPlayerController);
            }
            else
            {
                DataPlayerController = new DataPlayerController(0, 0, 0);
                Debug.LogWarning("No saved player data found.");
            }
            this.HeroBought = JsonUtility.FromJson<HeroBought>(PlayerPrefs.GetString("HeroBought", JsonUtility.ToJson(new HeroBought())));
            if (this.HeroBought == null) { this.HeroBought = new HeroBought(); }
            if (this.HeroBought.Indexs == null || this.HeroBought.Indexs.Count == 0) this.HeroBought.Indexs = new List<int>() { 0 };
        }

        public void SaveData()
        {
            //PlayerPrefs.SetString("HeroBought", JsonUtility.ToJson(HeroBought));
            string jsonDataPlayerController = JsonUtility.ToJson(DataPlayerController);
            PlayerPrefs.SetString("dataPlayerController", jsonDataPlayerController);
            PlayerPrefs.SetString("HeroBought", JsonUtility.ToJson(HeroBought));
            //Debug.Log(jsonDataPlayerController);
        }

        public GameObject GetHeroUIPrefabByIndex(int index)
        {
            GameObject avaPreb = Resources.Load<GameObject>("Avatar/No" + index);
            if (avaPreb != null)
            {
                return Instantiate(avaPreb);
            }
            Debug.LogError("Not found:" + index);
            return null;
        }
    }
}

