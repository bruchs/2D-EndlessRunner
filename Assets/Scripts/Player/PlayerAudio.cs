using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource healthSource, movementSource, animationSource;

    public AudioClip damagedClip, restoreClip, destroyedClip;
    public AudioClip jumpClip, footstepClip, teleportedClip;

    public void TriggerSoundEffect(AudioSource audioSource, AudioClip audioClip)
    {
        if (audioSource.isPlaying)
            audioSource.Stop();

        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
