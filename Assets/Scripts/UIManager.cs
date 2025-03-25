using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Private
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;
        public TextMeshProUGUI textGold;
        public GameObject LosePanel;
        public GameObject ShopObj;
        public TextMeshProUGUI PointOnGame;
        public TextMeshProUGUI PointOnPanel;
        public TextMeshProUGUI HightPoint;



        private void Awake()
        {
            if (Instance == null)
            Instance = this;
        }

        public void TextGOLD()
        {
            textGold.text = DataController.instance.DataPlayerController.gold.ToString();
            DataController.instance.SaveData();
        }
        public void Lose()
        {
            LosePanel.SetActive(true);
        }

        public void CLoseShop()
        {
            ShopObj.SetActive(false);
        }

        public void SetPoint()
        {
            PointOnPanel.text = DataController.instance.Point.ToString();
            PointOnGame.text = DataController.instance.Point.ToString();
            HightPoint.text = DataController.instance.DataPlayerController.HightPoint.ToString(); 

        }
    }
}

