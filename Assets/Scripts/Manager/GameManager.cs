using UnityEngine;
using UnityEngine.SceneManagement;

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
    public GameObject CameraReference;

    private PlayerMovement playerMovement;
    private PlayerAnimation playerAnimation;
    private PlayerHealth playerHealth;
    private PlayerAudio playerAudio;

    private CameraMovement cameraMovement;
    private CameraEffects cameraEffects;

    private void Awake()
    {
        SetInitialReferences();
    }

    private void SetInitialReferences()
    {
        playerMovement = PlayerReference.GetComponent<PlayerMovement>();
        playerAnimation = PlayerReference.GetComponentInChildren<PlayerAnimation>();
        playerHealth = PlayerReference.GetComponent<PlayerHealth>();
        playerAudio = PlayerReference.GetComponent<PlayerAudio>();

        cameraEffects = CameraReference.GetComponent<CameraEffects>();
        cameraMovement = CameraReference.GetComponent<CameraMovement>();
    }

    public void EndGame()
    {
        Destroy(PlayerReference);
        UIManager.instance.GetUIAnimation().TriggerGameOverAnimation();
        UIManager.instance.GetUIGame().SetResultsUI();
    }

    public void RestarScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public PlayerMovement GetPlayerMovement() { return playerMovement; }
    public PlayerAnimation GetPlayerAnimation() { return playerAnimation; }
    public PlayerHealth GetPlayerHealth() { return playerHealth; }
    public PlayerAudio GetPlayerAudio() { return playerAudio; }

    public CameraEffects GetCameraEffects() { return cameraEffects; }
    public CameraMovement GetCameraMovement() { return cameraMovement; }
}
