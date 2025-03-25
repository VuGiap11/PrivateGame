using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Private
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager instance;
        public AudioSource efxSource1;
        public AudioSource efxSource2;
        public AudioSource efxSource3;
        public AudioSource musicSource;
        public float lowPitchRange = 0.95f;
        public float highPitchRange = 1.05f;

        public AudioClip audioCoin;
        public AudioClip audioDie;
        public AudioClip audioBgm;
        public AudioClip audioSide;


        [SerializeField] Image SoundONIcon;
        [SerializeField] Image SoundOFFIcon;
        private bool muted = false;

        void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);

            if (PlayerPrefs.GetInt("FirstPlay", 0) == 0)
            {
                PlayerPrefs.SetInt("FirstPlay", 1);
                PlayerPrefs.SetInt("MusicOn", 1);
                PlayerPrefs.SetInt("SoundOn", 1);
            }
        }

        private void Start()
        {
            if (!PlayerPrefs.HasKey("muted"))
            {
                PlayerPrefs.SetInt("muted", 0);
                Load();
            }
            else
            {
                Load();
            }
            UpdateButtonIcon();
            AudioListener.pause = muted;
        }
        //Used to play single sound clips.
        public void PlaySingle(AudioClip clip)
        {
            if (efxSource1.isPlaying)
            {
                PlaySecond(clip);
            }
            else
            {
                efxSource1.PlayOneShot(clip);
            }
        }

        private void PlaySecond(AudioClip clip)
        {
            if (efxSource2.isPlaying)
            {
                PlayThird(clip);
            }
            else
            {
                efxSource2.PlayOneShot(clip);
            }
        }

        private void PlayThird(AudioClip clip)
        {
            efxSource3.PlayOneShot(clip);
        }

        public void PlayMusic(AudioClip clip)
        {
            //if (GameController.Instance.IsSoundOn)
            {
                musicSource.clip = clip;
                musicSource.Play();
            }
        }
        public void Mute()
        {
            musicSource.volume = 0;
            //efxSource1.volume = efxSource2.volume = efxSource3.volume = 0;
            PlayerPrefs.SetInt("MusicOn", 0);
        }

        public void ContinueMusic()
        {
            musicSource.volume = 0.5f;
            //efxSource1.volume = efxSource2.volume = efxSource3.volume = 1;
            PlayerPrefs.SetInt("MusicOn", 1);
        }
        public void ToggleSound(bool isOn)
        {

            if (!isOn)
            {
                efxSource1.volume = efxSource2.volume = efxSource3.volume = 0;
                PlayerPrefs.SetInt("SoundOn", 0);
                //PlayerPrefsX.SetBool("IsSoundOn", true);
            }
            else
            {
                efxSource1.volume = efxSource2.volume = efxSource3.volume = 1f;
                PlayerPrefs.SetInt("SoundOn", 1);
                //PlayerPrefsX.SetBool("IsSoundOn", false);
            }
            //if (withSound)
            //{
            //    PlaySingle(UISfxController.Instance.SfxSettingSound);
            //}
        }

        public void OnButtonPress()
        {
            PlaySingle(audioSide);
            if (muted == false)
            {
                muted = true;
                AudioListener.pause = true;
            }
            else
            {
                muted = false;
                AudioListener.pause = false;
            }
            Save();
            UpdateButtonIcon();
        }
        private void UpdateButtonIcon()
        {
            if (muted == false)
            {
                SoundONIcon.enabled = true;
                SoundOFFIcon.enabled = false;
            }
            else
            {
                SoundONIcon.enabled = false;
                SoundOFFIcon.enabled = true;
            }
        }
        private void Load()
        {
            muted = PlayerPrefs.GetInt("muted") == 1;
        }
        private void Save()
        {
            PlayerPrefs.SetInt("muted", muted ? 1 : 0);
        }
    }
}
