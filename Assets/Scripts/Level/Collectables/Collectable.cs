using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int scoreToAdd = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement playerReference = collision.gameObject.GetComponent<PlayerMovement>();

        if(playerReference != null)
        {
            ScoreManager.instance.AddScore(scoreToAdd);
            Instantiate(Resources.Load("Particles/Collectable Collected"), transform.position, transform.rotation, null);
            Destroy(this.gameObject);
        }
    }
}
