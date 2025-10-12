using System;
using System.Collections.Generic;
using UnityEngine;

namespace TitleGame
{
    [Serializable]
    public class IapDataCf
    {
        public string Id;
        public int Coin;
    }
    [Serializable]
    public class IapDataCfs
    {
        public List<IapDataCf> iapDataCfs;
    }
    public class DataAssets : MonoBehaviour
    {
        public static DataAssets instance;
        public List<Sprite> imageAvar;
        public IapDataCfs IapDataCfs;
        public TextAsset IapDataCfText;
        private void Awake()
        {
            if (instance == null)
                instance = this;
        }
        public void LoadDataIap()
        {
            this.IapDataCfs = JsonUtility.FromJson<IapDataCfs>(this.IapDataCfText.text);
        }
    }

}