# Audio-Management

## 1.0 - Audio levels Managing - Introduction
Audio levels are managed by AudioManager singleton which is responsible for saving and loading audio volume into player prefs it requires a scriptable object with the channels default values. 


## 2.0 - SFX - Introduction
SFXs (sound effects) are managed by SFX Manager which is responsible for reproducing SFX audio clips.
SFX are reproduced using an instance of an AudioSource moved in a defined position.

### 2.1 - SFX
Each SFX contains an AudioClip, Pitch and Spatial Blend.
SFX can be obtained by an **SFX_SO** scriptable with the **GetSFX** method.
**SFX_SO.GetSFX** will return an SFX with all the parameters setted up according to its serialized parameters.

> [!NOTE]
> Here's a list of the serialized parameters:
> - List<AudioClip> Clips
> - float StartingPitch
> - float PitchVariation
> - float SpatialBlend

Each SFX request is done by invoking the PlaySFX static action directly on SFXManager.PlaySFX(SFX, Vector3) .

All AudioSource instances used by SFX Manager are initialized disabled when an SFX is reproduced the AudioSource gameObject is set to enabled.
Pooling works on AudioSource.IsPlaying rather than on gameObject.ActiveInHierarchy.
