using UnityEngine;

namespace Private
{
    public class MastManager : MonoBehaviour
    {
        public static MastManager instance;
        public MastMove MastMovePre;
        public Transform SpawnPos;
        public Transform TargetPos1;
        public Transform TargetPos2;
        public MoveShip moveShip;
        private int index = 0; // ddeer spam khi thuyen di chuyen
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
        public void SpawnMast()
        {
                index += 1;
                if (index >= 2)
                {
                    GameManager.instance.minSpeed += 0.2f;
                    if (GameManager.instance.minSpeed >= GameManager.instance.MaxSpeed)
                    {
                        GameManager.instance.minSpeed = GameManager.instance.MaxSpeed;
                    }
                }
                MastMove mast = Instantiate(MastMovePre, transform.position, Quaternion.identity);
                mast.transform.SetParent(SpawnPos, false);
                mast.transform.localPosition = new Vector2(0f, 0f);
                mast.TargetPosMast1 = TargetPos1;
                mast.TargetPosMast2 = TargetPos2;
                mast.Init();
        }
    }

}
