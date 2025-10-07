using UnityEngine;
using UnityEngine.SceneManagement;

namespace TitleGame
{

    public class SceneController : MonoBehaviour
    {
        public static SceneController instance;

        private void Awake()
        {
            if (instance == null)
                instance = this;
        }


        public void LoadToSceneStartGame()
        {
            SceneManager.LoadScene(Contans.StartScene);
        }
    }

}