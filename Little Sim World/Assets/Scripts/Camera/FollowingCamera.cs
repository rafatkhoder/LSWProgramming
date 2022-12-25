using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    // The target to follow ( the player character)
    public Transform target;

    // The distance to keep between the camera and the target
    public float distance = 10.0f;

    // The speed at which the camera follows the target
    public float smoothSpeed = 5.0f;

    void LateUpdate()
    {
        // Calculate the desired position for the camera
        Vector3 desiredPosition = target.position + Vector3.back * distance;

        // Smoothly move the camera towards the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }
}
