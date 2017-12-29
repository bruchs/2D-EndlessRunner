using UnityEngine;

public class PlayerAnimationHelper : MonoBehaviour
{
    private PlayerAudio mPlayerAudio;

    private void Start()
    {
        mPlayerAudio = GameManager.instance.GetPlayerAudio();
    }

    public void TriggerFootstepSound()
    {
        mPlayerAudio.TriggerSoundEffect(mPlayerAudio.animationSource, mPlayerAudio.footstepClip);
    }

}
