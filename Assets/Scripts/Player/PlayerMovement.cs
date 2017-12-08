using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D mRigidbody;
    public Vector2 movementVector;
    public float movementSpeed;
    public float jumpForce;

    private bool isGrounded;

    private void Start()
    {
        SetInitialReferences();
    }

    private void SetInitialReferences()
    {
        mRigidbody = GetComponent<Rigidbody2D>();
    }

    // Manages Player Input
    private void FixedUpdate()
    {
        Run();
        Jump();
        Land();
    }

    private void Run()
    {
        transform.position += transform.right * (movementSpeed * Time.fixedDeltaTime);
        ScoreManager.instance.AddScore(1);
    }

    // TODO Add Double Jump
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Vector2 forceVector = transform.up * jumpForce;
            mRigidbody.AddForce(forceVector, ForceMode2D.Impulse);
        }
    }

    private void Land()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow) && !isGrounded)
        {
            Vector2 forceVector = -transform.up * jumpForce;
            mRigidbody.AddForce(forceVector, ForceMode2D.Impulse);
        }
    }

    public bool IsGrounded()
    {
        if (isGrounded) return true;
       
        return false;
    }

    // Grounded Collision Checking
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
            isGrounded = false;
    }
}
