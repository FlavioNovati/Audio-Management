using UnityEngine;

namespace Audio_System.Channel
{
    [System.Serializable]
    public class AudioChannel
    {
        [SerializeField] private AudioChannelType _audioChannelType;
        [SerializeField][Range(0f, 1f)] private float _defaultVolume = 0.75f;

        public AudioChannelType AudioChannelType => _audioChannelType;
        public float DefaultVolume => _defaultVolume;
    }
}
