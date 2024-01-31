using UnityEngine;

public class MobilePlayerLook : MonoBehaviour
{
    public float sensitivity = 2.0f; // Touch sensitivity
    public Transform playerBody; // Player's body to rotate

    private float xRotation = 0.0f;

    void Start()
    {
        // Lock cursor at the center of the screen
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Get touch input
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            // Rotate the player horizontally (around Y-axis)
            playerBody.Rotate(Vector3.up * touchDeltaPosition.x * sensitivity * Time.deltaTime);

            // Calculate vertical rotation (around X-axis)
            xRotation -= touchDeltaPosition.y * sensitivity * Time.deltaTime;
            xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f); // Limit vertical rotation

            // Apply vertical rotation to the camera
            transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);
        }
    }
}
