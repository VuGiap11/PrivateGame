using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;

namespace Private
{
    public class PlayerMoveMent : MonoBehaviour
    {  
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] SpriteRenderer spriteRenderer;
        public bool isDead;
  
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        //public void PlayerMove()
        //{//
        //    if (!isDead)
        //    {
        //        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        //        {
        //            if (transform.position.x >= 0)
        //            {

        //                spriteRenderer.flipX = false;
        //            }
        //            else
        //            {
        //                spriteRenderer.flipX = true;
        //            }
        //            transform.position = new Vector2(-transform.position.x, transform.position.y);
        //        }
        //    }
        //}
        public void PlayerMove()
        {//
            if (!isDead)
            {
                {
                    if (transform.position.x >= 0)
                    {

                        spriteRenderer.flipX = false;
                    }
                    else
                    {
                        spriteRenderer.flipX = true;
                    }
                    transform.position = new Vector2(-transform.position.x, transform.position.y);
                }
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Obstacle" && !isDead)
            {
                isDead = true;
                SoundManager.instance.PlaySingle(SoundManager.instance.audioDie);
                rb.bodyType = RigidbodyType2D.Dynamic;
                UIManager.Instance.Lose();
                //Time.timeScale = 0;
            }
            if (collision.tag == "Coin")
            {
                DataController.instance.DataPlayerController.gold += 1;
                UIManager.Instance.TextGOLD();
                SoundManager.instance.PlaySingle(SoundManager.instance.audioCoin);
                Destroy(collision.gameObject);
            }

            if (collision.tag == "Point" && !isDead)
            {
                DataController.instance.Point += 1;
                if (DataController.instance.Point >= 50)
                {
                    GameManager.instance.ChangeBg();
                }
                if (DataController.instance.Point >= DataController.instance.DataPlayerController.HightPoint)
                {
                    DataController.instance.DataPlayerController.HightPoint = DataController.instance.Point;

                }
                DataController.instance.SaveData();
                UIManager.Instance.SetPoint();
            }
        }
    }
}
