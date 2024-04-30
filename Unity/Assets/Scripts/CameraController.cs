using UnityEngine;

public class CameraController : MonoBehaviour
{
    //room camera
    [SerializeField] private float smoothTime;
    private float targetPosX;
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        // Smoothly move towards the target position
        Vector3 targetPosition = new Vector3(targetPosX, transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    public void MoveToNewRoom(Transform newRoomTransform)
    {
        if (newRoomTransform != null)
        {
            // Set the target position to the new room's x position
            targetPosX = newRoomTransform.position.x;
        }
        else
        {
            Debug.LogWarning("Trying to move to a null room transform.");
        }
    }
}
