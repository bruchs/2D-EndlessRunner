using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator mAnimator;
    private Rigidbody2D mRigidbody;
    private PlayerMovement mPlayerMovement;

    private void Start()
    {
        SetInitialReferences();
    }

    private void SetInitialReferences()
    {
        mAnimator = GetComponentInChildren<Animator>();
        mRigidbody = GetComponent<Rigidbody2D>();
        mPlayerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        SetCurrentAnimation();
    }

    private void SetCurrentAnimation()
    {
        if (mPlayerMovement.IsGrounded())
            mAnimator.SetBool("IsRunning", true);
        else
            mAnimator.SetBool("IsRunning", false);
    }

    public void SetDeadAnimationState()
    {
        mAnimator.SetBool("IsRunning", false);
        mAnimator.SetBool("IsDead", true);
    }
}
