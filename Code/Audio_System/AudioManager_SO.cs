using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;

using Audio_System.Channel;

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
