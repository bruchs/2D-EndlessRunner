using UnityEngine;

public class LevelDestroyer : MonoBehaviour
{
    private LevelManager levelManager;
    public float distanceFromPlayer = 25.0F;

    private void Start()
    {
        levelManager = LevelManager.instance;
    }

    private void Update()
    {
        if(GameManager.instance.PlayerReference != null)
        {
            Vector3 positionToFollow = GameManager.instance.PlayerReference.transform.position;
            transform.position = new Vector3(positionToFollow.x - distanceFromPlayer, 0.0F, 0.0F);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LevelSection currentPiece = collision.gameObject.GetComponent<LevelSection>();
        if (currentPiece != null)
        {
            Destroy(currentPiece.gameObject);
            levelManager.CheckForCurrentThreshold();
        }
    }
}
