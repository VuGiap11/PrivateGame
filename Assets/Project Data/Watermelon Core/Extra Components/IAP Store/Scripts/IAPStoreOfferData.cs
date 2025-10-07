using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TitleGame.IAPStore
{
    [System.Serializable]
    public class IAPStoreOfferData
    {
        [SerializeField] ProductKeyType productKey;
        [SerializeField] GameObject prefab;
    }
}
