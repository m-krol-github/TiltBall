using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField]
        private AudioSource sounds;

        [SerializeField]
        private AudioSource music;

        [SerializeField]
        private AudioMixer soundx;

        [SerializeField]
        private AudioMixer musix;

        [SerializeField]
        private Slider soundSlider;

        [SerializeField]
        private Slider musicSlider;

        #region GAME_AUDIO

        [SerializeField]
        private AudioClip timeOut;

        #endregion

        public void StartSounds()
        {
            soundSlider.value = PlayerPrefs.GetFloat("SoundVolume", 0.75f);
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        }

        public void UpdateSounds()
        {
            if(PlayerPrefs.GetInt("Music") == 1)
            {
                music.mute = false;
            }else if (PlayerPrefs.GetInt("Music") == 0)
            {
                music.mute = true;
            }

            if (PlayerPrefs.GetInt("Sound") == 1)
            {
                sounds.mute = false;
            }
            else if (PlayerPrefs.GetInt("Sound") == 0)
            {
                sounds.mute = true;
            }
        }

        public void SetSoundLevel(float sliderValue)
        {
            soundx.SetFloat("Sound", Mathf.Log10(sliderValue) * 20);
            PlayerPrefs.SetFloat("SoundVolume", sliderValue);
        }

        public void SetMusicVol(float sliderValue)
        {
            musix.SetFloat("Music", Mathf.Log10(sliderValue) * 20);
            PlayerPrefs.SetFloat("MusicVolume", sliderValue);
        }

        #region SOUNDS_PLAY

        public void StopAllSounds()
        {

        }

        public void PlayLastTenSeconds()
        {
            sounds.PlayOneShot(timeOut);
        }

        #endregion
    }
}