using System.Collections.Generic;
using UnityEngine;

namespace TitleGame
{

    public class DataAssets : MonoBehaviour
    {
        public static DataAssets instance;
        public List<Sprite> imageAvar;
        private void Awake()
        {
            if (instance == null)
                instance = this;
        }
    }

}