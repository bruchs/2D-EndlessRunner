using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<GameManager>();

            return _instance;
        }
    }

    private static GameManager _instance;
    public GameObject PlayerReference;
    private PlayerMovement playerMovement;
    private PlayerAnimation playerAnimation;

    private void Start()
    {
        SetInitialReferences();
    }

    private void SetInitialReferences()
    {
        playerMovement = PlayerReference.GetComponent<PlayerMovement>();
        playerAnimation = PlayerReference.GetComponent<PlayerAnimation>();
    }

    protected PlayerMovement GetPlayerMovement() { return playerMovement; }
    protected PlayerAnimation GetPlayerAnimation() { return playerAnimation; }
}
