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

    // Manages Player Movement
    private void FixedUpdate()
    {
        Run();
    }

    // Manages Player Input
    private void Update()
    {
        Jump();
    }

    private void Run()
    {
        transform.position += transform.right * (movementSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Vector2 nextPosition = transform.up * jumpForce;
            mRigidbody.AddForce(nextPosition, ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        if (isGrounded) return true;
        
        return false;
    }

    // TODO Remove Hardcoded LayerMask Number.
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
