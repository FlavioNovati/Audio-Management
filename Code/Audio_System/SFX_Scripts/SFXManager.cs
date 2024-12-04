using System;
using UnityEngine;
using System.Collections.Generic;

namespace Audio_System.SFX
{
    public class SFXManager : MonoBehaviour
    {
        public static Action<SFX, Vector3> PlaySFX = null;
        public static Action<AudioClip, Vector3> PlayClip = null;

        [SerializeField] private SFXManager_SO _SFXManagerSO;
        private List<AudioSource> _sources = new List<AudioSource>();

        private void Awake()
        {
            //Instanciate SFX Objects
            AudioSource source = _SFXManagerSO.SFX_Source;
            for (int i = 0; i < _SFXManagerSO.AudioSourcesAmount; i++)
                _sources.Add(Instantiate(source, transform));

            //Connect event
            PlaySFX += Play_SFX;
            PlayClip += Play_Clip;
        }

        private void OnDestroy()
        {
            PlaySFX -= Play_SFX;
            PlayClip -= Play_Clip;
        }

        private void Play_SFX(SFX sfx, Vector3 position)
        {
            if (sfx.Clip == null)
                return;

            //Find first available Source
            AudioSource source = GetFreeAudioSource();

            //Apply SFX to audio source
            source.transform.position = position;
            source.pitch = sfx.Pitch;
            source.clip = sfx.Clip;
            source.spatialBlend = sfx.SpatialBlend;
            source.Play();
        }

        private void Play_Clip(AudioClip clip, Vector3 position)
        {
            if (clip == null)
                return;

            AudioSource.PlayClipAtPoint(clip, position);
        }

        /// <summary>
        /// Returns the first free AudioSource, if no is free add new one
        /// </summary>
        private AudioSource GetFreeAudioSource()
        {
            for (int i = 0; i < _sources.Count; i++)
            {
                if (!_sources[i].isPlaying)
                {
                    //Reparent
                    _sources[i].transform.parent = this.transform;
                    return _sources[i];
                }
            }

            //Add new audio source
            Debug.LogWarning("SFX MANAGER - instanciated new SFX audio source, consider incrementing max SFX amount", this.gameObject);
            AudioSource source = _SFXManagerSO.SFX_Source;
            _sources.Add(Instantiate(source, transform));

            return _sources[^1];
        }
    }
}