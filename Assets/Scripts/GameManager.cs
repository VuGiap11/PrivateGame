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
        float referenceWidth = 1080f;  // Chiều rộng tham chiếu
        float referenceHeight = 1920f; // Chiều cao tham chiếu
        public GameObject clawMachineObj;
        private void Awake()
        {
            if (instance == null) 
            {
                instance = this;
            }
        }
        private void Start()
        {
            ScaleClawMachine();

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
        void ScaleClawMachine()
        {
            float referenceAspect = referenceWidth / referenceHeight;
            float scaleFactor = (float)Screen.width / referenceWidth;
            float aspectRatio = (float)Screen.width / Screen.height;
            //float aspectRatio = (float)Screen.height / Screen.width;
            Debug.Log("aspectRatio" + aspectRatio);
            Debug.Log("width" + Screen.width);
            Debug.Log("height" + Screen.height);
            if (aspectRatio >= 2.1f) // Điện thoại siêu dài (21:9)
            {
                clawMachineObj.transform.localScale = new Vector3(0.82f, 0.82f, 1);
            }
            else if (aspectRatio >= 1.8f) // Điện thoại phổ thông (19.5:9, 18:9)
            {
                clawMachineObj.transform.localScale = new Vector3(1.0f, 1.0f, 1);
            }
            else if (aspectRatio >= 1.5f) // Tablet hoặc điện thoại cũ (16:10, 4:3)
            {
                //1.5
                clawMachineObj.transform.localScale = new Vector3(0.9f, 0.9f, 1);
            }
            else // Màn hình vuông hoặc nhỏ
            {
                float scaleFactorWidth = (float)Screen.width / referenceWidth;  // Hệ số theo chiều rộng
                if (scaleFactorWidth >= 1f)
                {
                    clawMachineObj.transform.localScale = new Vector3(1f, 1f, 1f);
                }
                else
                {
                    clawMachineObj.transform.localScale = new Vector3(0.8f, 0.8f, 1);
                }
            }

        }
    }

}
