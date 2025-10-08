
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TitleGame
{
    [System.Serializable]
    public class DataPlayerController
    {
        public int gold;
        public bool isRemoveADS;
        public int level;
        public int levelrandom;
        public string namePlayer;
        public int idAvar;
    }
    public class DataController : MonoBehaviour
    {
        public static DataController instance;
        public DataPlayerController dataPlayerController;
        public bool isStopping;
        private void Awake()
        {
            if (instance == null)
                instance = this;
        }

        private void Start()
        {
           
        }
        public static bool IsFirstLogin()
        {
            if (!PlayerPrefs.HasKey("FirstLogin"))
            {
                PlayerPrefs.SetInt("FirstLogin", 1);
                PlayerPrefs.Save();
                return true;
            }
            return false;
        }
        [ContextMenu("LoadData")]
        public void LoadData()
        {
            this.isStopping = false;
            string jsonDataPlayerController = PlayerPrefs.GetString("dataPlayerController");

            if (!string.IsNullOrEmpty(jsonDataPlayerController))
            {
                dataPlayerController = JsonUtility.FromJson<DataPlayerController>(jsonDataPlayerController);
            }
            else
            {
                this.dataPlayerController.gold =20000;
                this.dataPlayerController.isRemoveADS = false;
                this.dataPlayerController.level = 0;
                this.dataPlayerController.levelrandom = 0;
                this.dataPlayerController.idAvar = 0;
                Debug.LogWarning("No saved player data found.");
            }
            SaveData();
        }


        [ContextMenu("SaveData")]
        public void SaveData()
        {
            string jsonDataPlayerController = JsonUtility.ToJson(dataPlayerController);
            PlayerPrefs.SetString("dataPlayerController", jsonDataPlayerController);
        }
        public void AddGold(int gold)
        {
            this.dataPlayerController.gold += gold;
            SaveData();
        }
    }
}