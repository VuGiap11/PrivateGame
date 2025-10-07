using NTPackage.UI;
using UnityEngine;

namespace Rubik.TitleGame
{
    public class SoundController : MonoBehaviour
    {
        public static SoundController instance;
        public AudioSource efxSource1;
        public AudioSource efxSource2;
        public AudioSource efxSource3;
        public AudioSource musicSource;
        public float lowPitchRange = 0.95f;
        public float highPitchRange = 1.05f;

        //[SerializeField] private Image SoundONIcon;
        //[SerializeField] private Image SoundOFFIcon;
        //public bool muted = false;
        public AudioClip audioSide;
        [SerializeField] private AudioClip buttonAudio, exitBtnAudio;
        //[SerializeField] private AudioClip VictoryAudio;
        //[SerializeField] private AudioClip DefeatAudio;
        public bool mutedSound = false;
        public bool mutedMusic = false;
        public AudioClip audioReceiReward;
        void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);

            //if (PlayerPrefs.GetInt("FirstPlay", 0) == 0)
            //{
            //    PlayerPrefs.SetInt("FirstPlay", 1);
            //    PlayerPrefs.SetInt("MusicOn", 1);
            //    PlayerPrefs.SetInt("SoundOn", 1);
            //}
        }
        private void Start()
        {
            //if (!PlayerPrefs.HasKey("muted"))
            //{
            //    PlayerPrefs.SetInt("muted", 0);
            //    Load();
            //}
            //else
            //{
            //    Load();
            //}
            //UpdateButtonIcon();
            //AudioListener.pause = muted;


            startSound();
        }
        public void startSound()
        {
            if (!PlayerPrefs.HasKey("mutedSound"))
            {
                PlayerPrefs.SetInt("mutedSound", 0);
                PlayerPrefs.Save();
                //    Load();
                //}
                //else
                //{
                //    Load();
            }
            if (!PlayerPrefs.HasKey("mutedMusic"))
            {
                PlayerPrefs.SetInt("mutedMusic", 0);
                PlayerPrefs.Save();
                //    Load();
                //}
                //else
                //{
                //    Load();
            }
            Load();
            SoundOnOff(this.mutedSound);
            MusicOnOff(this.mutedMusic);
            PlayMusicBackGround();
        }
        private void Load()
        {
            mutedSound = PlayerPrefs.GetInt("mutedSound") == 1;
            mutedMusic = PlayerPrefs.GetInt("mutedMusic") == 1;
        }
        public void PlayMusicBackGround()
        {
            Debug.Log("aaaaaaaa");
            PlayMusic(this.audioSide);
        }
        public void AudioButton()
        {
            //PlaySingle(this.buttonAudio);
            PlaySingle(this.exitBtnAudio);
        }
        public void AudioExitButton()
        {
            PlaySingle(this.exitBtnAudio);
        }
        public void PlayMusic(AudioClip clip)
        {
            //if (GameController.Instance.IsSoundOn)
            //{

            musicSource.clip = clip;
           // musicSource.PlayOneShot(clip);
            musicSource.Play();
            //}
        }
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
        public void PressButtonAudio()
        {
            PlaySingle(buttonAudio);
        }
        public void SoundOnOff(bool muted)
        {

            if (!muted)
            {
                efxSource1.volume = efxSource2.volume = efxSource3.volume = 0.5f;
             
            }
            else
            {
                efxSource1.volume = efxSource2.volume = efxSource3.volume = 0f;
            }
        }

        public void MusicOnOff(bool muted)
        {

            if (!muted)
            {
                musicSource.volume =  0.5f;
            }
            else
            {
                musicSource.volume  = 0f;
            }
        }

        public void AudioReward()
        {
            PlaySingle(this.audioReceiReward);
            Debug.Log("audioreward");
        }
    }
}
