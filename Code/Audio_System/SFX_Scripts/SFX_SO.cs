using UnityEngine;
using System.Collections.Generic;

namespace Audio_System.SFX
{
    [CreateAssetMenu(fileName = "New SFX", menuName = "Settings/Audio/SFX/SFX")]
    public class SFX_SO : ScriptableObject
    {
        [SerializeField] public List<AudioClip> Clips = null;
        [SerializeField] public float StartingPitch = 1f;
        [SerializeField] public float PitchVariation = 0f;
        [SerializeField, Range(0f, 1f)] public float SpatialBlend = 1f;

        public SFX GetSFX()
        {
            //Get Pich Variation
            float pitchVariation = UnityEngine.Random.Range(-PitchVariation, +PitchVariation);
            //Get Audio Clip
            AudioClip audioClip = Clips[UnityEngine.Random.Range(0, Clips.Count)];
            
            return new SFX(audioClip, StartingPitch + pitchVariation, SpatialBlend);
        }
    }
}
