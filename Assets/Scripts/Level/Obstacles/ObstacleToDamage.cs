using UnityEngine;

public class ObstacleToDamage : MonoBehaviour
{
    public string particleToSpawn;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

        if(playerHealth != null)
        {
            playerHealth.RecieveDamage();
            Instantiate(Resources.Load("Particles/" + particleToSpawn), transform.position, transform.rotation);

            PlayerAudio playerAudio = playerHealth.gameObject.GetComponent<PlayerAudio>();
            playerAudio.TriggerSoundEffect(playerAudio.healthSource, playerAudio.damagedClip);

            Destroy(this.gameObject);
        }
    }
}
