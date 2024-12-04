using UnityEngine;

namespace Audio_System.SFX
{
    [System.Serializable]
    public class SFX
    {
        [HideInInspector] public AudioClip Clip;
        [HideInInspector] public float Pitch;
        [HideInInspector] public float SpatialBlend;

        public SFX(AudioClip audioClip, float pitch, float spatialBlend)
        {
            Clip = audioClip;
            Pitch = pitch;
            SpatialBlend = spatialBlend;
        }
    }
}
