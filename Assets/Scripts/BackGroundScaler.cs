using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace Private
{
    public class BackGroundScaler : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;
        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            BGscale();
        }
        private void BGscale()
        {
            float cameraHeight = Camera.main.orthographicSize * 2f;
            float camerawitdh = cameraHeight * Camera.main.aspect;

            float bgHeight = spriteRenderer.bounds.size.y;
            float bgWidth = spriteRenderer.bounds.size.x;

            float scaleX = camerawitdh / bgWidth;
            float scaleY = cameraHeight / bgHeight;
            transform.localScale = new Vector3(scaleX, scaleY, 1f);
        }
        public void Blink()
        {
            //Color color = spriteRenderer.color;
            //spriteRenderer.DOColor(new Color(color.r, color.g, color.b, 100), fadeDuration)
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.5f);
        }

    }
}

