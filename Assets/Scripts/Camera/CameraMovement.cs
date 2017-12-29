using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public Vector3 targetOffset;
    private Vector3 offsetToFollow;
    private Vector3 lastPositionFollowed;

    private void Start()
    {
        offsetToFollow = targetOffset;
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.PlayerReference != null)
        {
            Vector3 currentTarget = GameManager.instance.PlayerReference.transform.position;
            lastPositionFollowed = currentTarget;
            FollowTarget(currentTarget);
        }
        else
        {
            FollowTarget(lastPositionFollowed);
            SetOffset(new Vector3());
        }
    }

    private void FollowTarget(Vector3 targetPosition)
    {
        // Set The Position To Follow To Be Our Target Without The 'Y' Axis.
        Vector3 positionToFollow = targetPosition;
        Vector2 currentPosition = new Vector2(transform.position.x, 0.0f);

        positionToFollow = Vector2.Lerp(currentPosition, new Vector2(positionToFollow.x, 0.0F), Time.deltaTime * 1.5F);
        // Add An Offset To Set The Camera To The Desired Position.
        positionToFollow += targetOffset;
        transform.position = positionToFollow;   
    }

    public void SetOffset(Vector3 newOffset)
    {
        targetOffset = new Vector3(newOffset.x, newOffset.y, -10.0f);
    }

    public IEnumerator SetNormalOffset()
    {
        yield return new WaitForSeconds(0.1F);
        targetOffset = offsetToFollow;
    }
}
