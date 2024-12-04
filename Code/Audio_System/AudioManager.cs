using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;

using Audio_System.Channel;
using Audio_System.SFX;

namespace Audio_System
{
    [RequireComponent(typeof(SFXManager))]
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;

        [Header("Audio Settings")]
        [SerializeField] private AudioManager_SO _audioManagerSO;

        private static List<AudioChannel> _audioChannels;
        private static AudioMixer _mixer;

        private void Awake()
        {
            //Singleton set up
            if (Instance != null)
            {
                Destroy(this.gameObject);
                return;
            }
            else
                Instance = this;
        }

        private void Start()
        {
            SetUpAudio();
        }

        private void SetUpAudio()
        {
            _mixer = _audioManagerSO.Mixer;
            _audioChannels = _audioManagerSO.AudioData_List;
            //Audio is saved in decimal scale an then converted
            float volume = 0f;
            for (int i = 0; i < _audioChannels.Count; i++)
            {
                volume = GetVolume(_audioChannels[i].AudioChannelType);
                SetVolume(_audioChannels[i].AudioChannelType, volume);
            }
        }
        
        /// <summary>
        /// Change audio volume and save it into player prefs
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="volume"></param>
        public static void SetVolume(AudioChannelType channel, float volume)
        {
            //Update Player Prefs
            PlayerPrefs.SetFloat(channel.ToString() + "Volume", volume);

            //Convert audio volume
            volume = 20 * Mathf.Log10(volume);
            if (volume < -80f)
                volume = -80f;
            //Set Mixer volume
            _mixer?.SetFloat(channel.ToString() + "Volume", volume);
        }
        
        public static float GetVolume(AudioChannelType channel) => PlayerPrefs.GetFloat(channel.ToString() + "Volume", GetDefaultVolume(channel));

        private static float GetDefaultVolume(AudioChannelType audioChannel)
        {
            if (_audioChannels == null)
                return 0f;

            for(int i = 0; i < _audioChannels.Count; i++)
                if (_audioChannels[i].AudioChannelType == audioChannel)
                    return _audioChannels[i].DefaultVolume;
               
            return 0f;
        }
    }
}
