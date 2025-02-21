using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 5f; // Sensitivity of the rotation    

    [SerializeField] float minPitch = -180f; // Minimum downward tilt (downward limit)
    [SerializeField] float maxPitch = 0f;   // Maximum tilt (horizontal, no looking up)

    float yaw = 0f;     // Here so we dont have to get the value from the camera each frame
    float pitch = 90.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to center
        Cursor.visible = false; // Hide cursor
    }

    void Update()
    {
        // Get mouse movement
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        // Update yaw (left-right rotation)
        yaw += mouseX;

        // Update pitch (up-down rotation) but clamp it so it never tilts up past horizontal
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        // Apply rotation
        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
    }
}
