using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Private
{
    public class MoveShip : MonoBehaviour
    {
        public Transform Target2;

        public void ShiMoveMent()
        {
            MastManager.instance.SpawnMast();
            transform.DOMove(Target2.position, GameManager.instance.minSpeed)
         .SetEase(Ease.Linear)
         .SetSpeedBased(true)
         .OnStart(() => { })
        .OnComplete(() =>
        {
            Destroy(gameObject);
        });
        }
    }
}

