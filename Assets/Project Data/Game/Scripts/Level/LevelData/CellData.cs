using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TitleGame
{
    [System.Serializable]
    public class CellData
    {
        public bool IsFilled;
        public TileEffectType Effect = TileEffectType.None;
    }
}
