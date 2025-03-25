using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

namespace Private
{
    public class MastMove : MonoBehaviour
    {
        public Transform TargetPosMast1;
        public Transform TargetPosMast2;
        public Transform[] ObstaclePos;
        public Transform[] GoldPos;

        public GameObject ObstaclePre;
        public GameObject GoldPre;
        public int ObsNumber = 2;
        public int GoldNumber = 5;

        public void Init()
        {
            SpawnObstacle();
            SpawnGold();
            MoveTarget1();

        }
        //transform.DOKill(); dừng ở giữa trừng khi đang gọi 
        
        public void MoveTarget1()
        {
            {
                transform.DOMove(TargetPosMast1.position, GameManager.instance.minSpeed)
                .SetEase(Ease.Linear)
                .OnStart(() => { })
                .SetSpeedBased(true)
                .OnComplete(() =>
        {
          MastManager.instance.SpawnMast();
             MoveTarget2();
         });
            }

        }
        public void MoveTarget2()
        {
                transform.DOMove(TargetPosMast2.position, GameManager.instance.minSpeed)
            .SetEase(Ease.Linear)
            .OnStart(() => { })
            .SetSpeedBased(true)
            .OnComplete(() =>
                {
            Destroy(gameObject);
                });
        }

        public void SpawnObstacle()
        {
            if (ObstaclePos.Length < ObsNumber)
            {
                Debug.Log("không đủ vị trí sinh ra obstacle");
                return;
            }
            List<int> availableIndices = new List<int>();
            for (int i = 0; i < ObstaclePos.Length; i++)
            {
                availableIndices.Add(i);
            }
            for (int i = 0; i < ObsNumber; i++)
            {
                int randomIndex = Random.Range(0, availableIndices.Count);
                int spawnIndex = availableIndices[randomIndex];
                GameObject Obs = Instantiate(ObstaclePre, ObstaclePos[spawnIndex].position, Quaternion.identity);
                Obs.transform.SetParent(ObstaclePos[spawnIndex]);
                if (ObstaclePos[spawnIndex].position.x < 0)
                {
                    Obs.transform.localScale = new Vector2(-1f, 1f);
                }
                Obs.transform.localPosition = new Vector2(0f, 0f);
                availableIndices.RemoveAt(randomIndex);
            }
        }
        public void SpawnGold()
        {

            if (GoldPos.Length < GoldNumber)
            {
                Debug.Log("không đủ vị trí sinh ra Gold");
                return;
            }
            List<int> availableIndices = new List<int>();
            for (int i = 0; i < GoldPos.Length; i++)
            {
                availableIndices.Add(i);
            }
            for (int i = 0; i < GoldNumber; i++)
            {
                int randomIndex = Random.Range(0, availableIndices.Count);
                int spawnIndex = availableIndices[randomIndex];
                GameObject Obs = Instantiate(GoldPre, GoldPos[spawnIndex].position, Quaternion.identity);
                Obs.transform.SetParent(GoldPos[spawnIndex]);

                Obs.transform.localPosition = new Vector2(0f, 0f);
                availableIndices.RemoveAt(randomIndex);
            }
        }
    }

}
