using NTPackage.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TitleGame
{
    public class SoundPanel : PopupUI
    {
        [SerializeField] Image imageRefsound;

        [SerializeField] Sprite activeSpritesound;
        [SerializeField] Sprite disableSpritesound;

        private bool isActivesound = true;

        [SerializeField] Image imageRefVibration;

        [SerializeField] Sprite activeSpriteVibration;
        [SerializeField] Sprite disableSpriteVibration;
        private bool isActive = true;
        public override void OnUI(object data = null)
        {
            base.OnUI(data);
            isActivesound = AudioController.GetVolume() != 0;

            if (isActivesound)
                imageRefsound.sprite = activeSpritesound;
            else
                imageRefsound.sprite = disableSpritesound;

            isActive = AudioController.IsVibrationEnabled();

            if (isActive)
                imageRefVibration.sprite = activeSpriteVibration;
            else
                imageRefVibration.sprite = disableSpriteVibration;
        }

        public void OneClickSound()
        {

            isActivesound = !isActivesound;

            if (isActivesound)
            {
                imageRefsound.sprite = activeSpritesound;
                AudioController.SetVolume(1f);
            }
            else
            {
                imageRefsound.sprite = disableSpritesound;
                AudioController.SetVolume(0f);
            }

            // Play button sound
            AudioController.PlaySound(AudioController.Sounds.buttonSound);
        }
        public void Vibration()
        {
            isActive = !isActive;

            if (isActive)
            {
                imageRefVibration.sprite = activeSpriteVibration;

                AudioController.SetVibrationState(true);
            }
            else
            {
                imageRefVibration.sprite = disableSpriteVibration;

                AudioController.SetVibrationState(false);
            }

            // Play button sound
            AudioController.PlaySound(AudioController.Sounds.buttonSound);
        }
    }

}