using System.Collections.Generic;
using UnityEngine;
using Audio_System.Channel;
using UnityEngine.Audio;

namespace Audio_System
{
    [CreateAssetMenu(fileName = "New Audio Manager", menuName = "Settings/Audio/Audio Manager")]
    public class AudioManager_SO : ScriptableObject
    {
        [Header("Audio Settings")]
        [SerializeField] public List<AudioChannel> AudioData_List;
        [SerializeField] public AudioMixer Mixer;
    }
}
