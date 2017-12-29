using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D mRigidbody;
    private PlayerAudio mPlayerAudio;
    private float totalDistance;
    private float startingDistance;

    public Vector2 movementVector;
    public float movementSpeed;
    public float jumpForce;

    private void Start()
    {
        SetInitialReferences();
        startingDistance = transform.position.x;
    }

    private void SetInitialReferences()
    {
        mRigidbody = GetComponent<Rigidbody2D>();
        mPlayerAudio = GetComponent<PlayerAudio>();
    }

    // Manages Player Input
    private void Update()
    {
        Jump();
        Land();
    }

    // Manages Movement
    private void FixedUpdate()
    {
        Run();
    }

    private void Run()
    {
        transform.position += transform.right * (movementSpeed * Time.fixedDeltaTime);
        totalDistance = transform.position.x - startingDistance;
    }

    private void Jump()
    {
        if (Input.GetMouseButtonDown(0) && IsGrounded())
        {
            Vector2 forceVector = transform.up * jumpForce;
            mRigidbody.AddForce(forceVector, ForceMode2D.Impulse);

            mPlayerAudio.TriggerSoundEffect(mPlayerAudio.movementSource, mPlayerAudio.jumpClip);
        }
    }

    private void Land()
    {
        if(Input.GetMouseButtonDown(0) && !IsGrounded())
        {
            Vector2 forceVector = -transform.up * jumpForce;
            mRigidbody.AddForce(forceVector, ForceMode2D.Impulse);
        }
    }

    public bool IsGrounded()
    {
        /* Use Two Different Raycasts To Check If The Player Is Grounded On His Left Or Right 'Leg' */

        int layerToDetect = LayerMask.NameToLayer("Ground");

        Vector3 rightRayPos = new Vector3(transform.position.x + 0.25F, transform.position.y - 0.75f, transform.position.z);
        Vector3 leftRayPos = new Vector3(transform.position.x - 0.25F, transform.position.y - 0.75F, transform.position.z);

        bool isGroundedRight = Physics2D.Raycast(rightRayPos, -transform.up, 0.25F, 1 << layerToDetect);
        bool isGroundedLeft = Physics2D.Raycast(leftRayPos, -transform.up, 0.25F, 1 << layerToDetect);

        if (isGroundedRight || isGroundedLeft) return true;
        else return false;
    }

    public float GetTotalDistance(){ return totalDistance; }
}
