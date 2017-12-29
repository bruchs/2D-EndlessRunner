using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform exitLocation;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();

        if(playerMovement != null)
        {
            /* Changes The Player's GameObject Position To The Exit Location */
            playerMovement.transform.position = exitLocation.position;
            Instantiate(Resources.Load("Particles/Warp"), exitLocation.transform.position, exitLocation.transform.rotation);

            PlayerAudio playerAudio = playerMovement.gameObject.GetComponent<PlayerAudio>();
            playerAudio.TriggerSoundEffect(playerAudio.movementSource, playerAudio.teleportedClip);

            CameraMovement cameraMovement = GameManager.instance.GetCameraMovement();

            cameraMovement.SetOffset(new Vector3());
            StartCoroutine(cameraMovement.SetNormalOffset());
        }
    }
}
