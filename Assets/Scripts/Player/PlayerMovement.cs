using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D mRigidbody;
    public Vector2 movementVector;
    public float movementSpeed;
    public float jumpForce;

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
        IsGrounded();
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 nextPosition = transform.up * jumpForce;
            mRigidbody.AddForce(nextPosition, ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        Vector3 RayPosition = new Vector3(transform.position.x, transform.position.y - 0.525F, transform.position.z);
        Debug.DrawRay(RayPosition, -transform.up, Color.red);

        if (Physics.Raycast(RayPosition, -transform.up, 0.5F))
        {
            print("***Grounded Status: true");
            return true;
        }
        print("***Grounded Status: false");
        return false;
    }
}
