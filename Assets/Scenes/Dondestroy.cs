using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Rubik.TitleGame
{
    public class Dondestroy : MonoBehaviour
    {
        //private void Awake()
        //{
        //    DontDestroyOnLoad(this);

        //    //cobidak
        //}
        private static Dondestroy instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {

                Destroy(gameObject); // Nếu đã có instance, hủy đối tượng mới
            }
        }
    }
}