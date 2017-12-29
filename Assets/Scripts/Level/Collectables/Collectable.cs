using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int scoreToAdd = 5;
    public float energyToAdd = 1.0F;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

        if(playerHealth != null)
        {
            if(ScoreManager.instance != null)
                ScoreManager.instance.AddScore(scoreToAdd);

            if(UIManager.instance != null)
                UIManager.instance.GetUIAnimation().TriggerEnergyCollectedAnim();

            playerHealth.AddEnergy(energyToAdd);
            // Get The Player Audio Reference To Trigger The Restored Sound Effect.
            PlayerAudio playerAudio = playerHealth.gameObject.GetComponent<PlayerAudio>();
            playerAudio.TriggerSoundEffect(playerAudio.healthSource, playerAudio.restoreClip);

            Instantiate(Resources.Load("Particles/Collectable Collected"), transform.position, transform.rotation, null);
            Destroy(this.gameObject);
        }
    }
}
