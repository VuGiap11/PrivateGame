using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Private
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        public bool IsStart;
        public float minSpeed = 2f;
        public float MaxSpeed = 8f;
        public Transform PlayerPos;

        public int IndexPlayer = 0;
        public GameObject SceneStart;
        public BackGroundScaler backGroundScaler;
        public PlayerMoveMent PlayerMoveMent;

        private void Awake()
        {
            if (instance == null) 
            {
                instance = this;
            }
        }
        private void Start()
        {
            UIManager.Instance.TextGOLD();
        }
        public void StartGame()
        {
            IsStart = true;
            SceneStart.SetActive(false);
            SpawnPlayer(IndexPlayer);
            MastManager.instance.moveShip.ShiMoveMent();
            UIManager.Instance.TextGOLD();
            UIManager.Instance.SetPoint();
            SoundManager.instance.PlaySingle(SoundManager.instance.audioSide);
            SoundManager.instance.PlayMusic(SoundManager.instance.audioBgm);
        }
        public void ResetGame()
        {
            SceneManager.LoadScene("GamePlay");
        }
        public void SpawnPlayer(int index)
        {
            Myfuntion.ClearChild(PlayerPos);
            GameObject avaPreb = Resources.Load<GameObject>("Player/No" + index);
            //if (avaPreb != null)
            //{
            //    return Instantiate(avaPreb);
            //}
            //Debug.LogError("Not found:" + index);
            //return null;
            GameObject player = Instantiate(avaPreb);
            if (player.TryGetComponent(out PlayerMoveMent playermoverment))
            {
                PlayerMoveMent = playermoverment;
            }
            player.transform.SetParent(PlayerPos);
            player.transform.localPosition = Vector3.zero;
            player.transform.localScale = Vector3.one;
        }

        public void ChangeBg()
        {
            backGroundScaler.Blink();
        }
        public void PlayGame()
        {
            PlayerMoveMent.PlayerMove();
        }
    }

}
