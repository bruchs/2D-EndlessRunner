using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    private Camera mCamera;
    private Vector3 originalPosition;

    public float shakeTime = 2.5F;
    public float shakeAmount = 0.5F;
    private float shakeTimer = 0.0F;

    private void Start()
    {
        mCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        ApplyShake();
    }

    private void CameraShake()
    {
        if (shakeTimer > 0)
        {
            float quakeAmount = Random.value * shakeAmount * 2 - shakeAmount;
            Vector3 nextPosition = mCamera.transform.position;

            nextPosition.y += quakeAmount;
            mCamera.transform.position = nextPosition;
        }
    }

    public void ApplyShake()
    {
        shakeTimer -= Time.deltaTime;

        if (shakeTimer > 0.0F) CameraShake();
        else shakeTimer = 0.0F;
    }

    public void ResetShakeTimer() { shakeTimer = shakeTime; }
}