using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float forceToAdd = 5.0F;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            Rigidbody2D rigidbodyToAddForce = playerMovement.GetComponent<Rigidbody2D>();

            Vector2 forceVector = transform.up * forceToAdd;
            rigidbodyToAddForce.AddForce(forceVector, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            Rigidbody2D rigidbodyToAddForce = playerMovement.GetComponent<Rigidbody2D>();

            Vector2 forceVector = -transform.up * forceToAdd;
            rigidbodyToAddForce.AddForce(forceVector, ForceMode2D.Impulse);
        }
    }
}
