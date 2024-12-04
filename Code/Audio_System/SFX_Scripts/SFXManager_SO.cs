using UnityEngine;

namespace Audio_System.SFX
{
    [CreateAssetMenu(fileName = "New SFX Manager", menuName = "Settings/Audio/SFX/SFX Manager")]
    public class SFXManager_SO : ScriptableObject
    {
        [Header("SFX Settings")]
        [SerializeField] public AudioSource SFX_Source;
        [SerializeField] public int AudioSourcesAmount = 1;
    }
}
