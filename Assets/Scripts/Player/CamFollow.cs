using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float minXClamp = 1.77f;
    public float maxXClamp = 150.0f;

    private void LateUpdate()
    {
        // Ensure player is assigned
        if (player == null)
        {
            Debug.LogWarning("Player transform not assigned to the camera!");
            return;
        }

        // Get the desired camera position based on player's position
        Vector3 desiredCameraPos = new Vector3(player.position.x, transform.position.y, transform.position.z);

        // Clamp the x position
        desiredCameraPos.x = Mathf.Clamp(desiredCameraPos.x, minXClamp, maxXClamp);

        // Update camera position
        transform.position = desiredCameraPos;
    }
}

