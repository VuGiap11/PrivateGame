using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Tool.MagicStick
{
    public class MagicStickController : MonoBehaviour
    {
        [SerializeField] GameObject wingLeft, wingRight;
        public bool stopAnimWing = false;
        float durationWing = 0.25f;
        Vector3 originPosMagicStick, originPosMoveYMagicStick, oriScaleMagicStick;

        void Awake()
        {
            originPosMagicStick = transform.position;
            oriScaleMagicStick = transform.localScale;
        }
        //[ContextMenu("StartAnimMagicStick")]
        //public void StartAnimMagicStick()
        //{
        //    int degreeWing = 10;
        //    stopAnimWing = false;
        //    StartWingAnim(wingLeft, degreeWing);
        //    StartWingAnim(wingRight, -degreeWing);
        //    MoveMagicStick();
        //}
        public void StartAnimMagicStick(System.Action callback = null)
        {
            int degreeWing = 10;
            stopAnimWing = false;
            StartWingAnim(wingLeft, degreeWing);
            StartWingAnim(wingRight, -degreeWing);
            MoveMagicStick(callback);
        }
        public void StopAnimMagicStick()
        {
            stopAnimWing = true;
            DOTween.Clear();
            transform.position = originPosMagicStick;
            transform.localScale = oriScaleMagicStick;
        }
        void MoveMagicStick(System.Action callback = null)
        {
            DOTween.Sequence()
            .Append(transform.DOMove(new Vector3(transform.position.x + 0f, transform.position.y + 1f, transform.position.z), 0.5f))
            .Join(transform.DORotate(new Vector3(0, 0, 0), 0.5f))
            .Join(transform.DOScale(new Vector3(transform.localScale.x * 2, transform.localScale.y * 2), 0.5f))
            .OnComplete(() =>
            {
                originPosMoveYMagicStick = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                callback?.Invoke();
                MoveYMagicStick();
            });
        }
        void MoveYMagicStick()
        {
            DOTween.Sequence()
            .Append(transform.DOMoveY(originPosMoveYMagicStick.y + 0.15f, 0.5f))
            .Append(transform.DOMoveY(originPosMoveYMagicStick.y - 0.15f, 0.5f))
            .OnComplete(() =>
            {
                if (!stopAnimWing)
                {
                    MoveYMagicStick();
                }
            });
        }
        void StartWingAnim(GameObject wing, int degreeWing)
        {
            wing.transform.DORotate(new Vector3(0, 0, degreeWing), durationWing);
            AnimWingAnim(wing, degreeWing);
        }
        void AnimWingAnim(GameObject wing, int degreeWing)
        {
            DOTween.Sequence()
            .Append(wing.transform.DORotate(new Vector3(0, 0, -degreeWing * 2), durationWing))
            .Append(wing.transform.DORotate(new Vector3(0, 0, degreeWing * 2), durationWing))
            .OnComplete(() =>
            {
                if (!stopAnimWing)
                {
                    AnimWingAnim(wing, degreeWing);
                }
                else
                {
                    wing.transform.DORotate(new Vector3(0, 0, 0), 0);
                }
            });
        }
    }

}