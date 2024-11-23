using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The object the camera should follow
    public float smoothSpeed = 0.125f; // Speed of the smoothing
    public Vector3 offset; // Offset from the target

    void FixedUpdate()
    {
        if (target != null)
        {
            // Calculate desired position
            Vector3 desiredPosition = target.position + offset;

            // Lock Z-axis to -10 (or any other fixed value you want)
            desiredPosition.z = -10f;

            // Smoothly interpolate between current position and desired position
            // Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Update camera position
            transform.position = desiredPosition;
        }
    }
}
