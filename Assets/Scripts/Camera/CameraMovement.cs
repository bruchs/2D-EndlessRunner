using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Vector3 targetOffset;

    private void Update()
    {
        Transform currentTarget = GameManager.instance.PlayerReference.transform;
        FollowTarget(currentTarget);
    }

    private void FollowTarget(Transform target)
    {
        // Set The Position To Follow To Be Our Target Without The 'Y' Axis.
        Vector3 positionToFollow = target.position;
        positionToFollow = new Vector3(positionToFollow.x, 0.0F, 0.0F);

        // Add An Offset To Set The Camera To The Desired Position.
        positionToFollow += targetOffset;
        transform.position = positionToFollow;
    }
}
