using UnityEngine;

public class LevelKillbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

        if(playerHealth != null)
        {
            playerHealth.KillPlayer();
            Vector3 particlePosition = new Vector3(playerHealth.transform.position.x - 1.5F, 
                    playerHealth.transform.position.y + 2F, playerHealth.transform.position.z);
        }
    }
}
