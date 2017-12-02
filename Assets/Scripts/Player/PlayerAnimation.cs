using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator mAnimator;
    private Rigidbody2D mRigidbody;

    private void Start()
    {
        SetInitialReferences();
    }

    private void SetInitialReferences()
    {
        mAnimator = GetComponent<Animator>();
        mRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        SetCurrentAnimation();
    }

    private void SetCurrentAnimation()
    {
        // TODO Check For Player State (Dead Or Alive).
        // TODO Check For Player Grounded.

        // If Player Speed Is Greater Than 0 and Player Is Not Jumping
        if (mRigidbody.velocity.x > 0.0F)
        {
            mAnimator.SetBool("IsRunning", true);
        }
        else
            mAnimator.SetBool("IsRunning", false);
    }
}
