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
        public TextMeshProUGUI PointOnGame;



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

        public void SetPoint()
        {
            PointOnGame.text = DataController.instance.Point.ToString();
        }
    }
}

