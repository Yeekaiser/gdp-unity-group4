using UnityEngine;

public class JoystickMovement : MonoBehaviour
{
    public Joystick joystick; // Reference to the joystick from the Joystick Pack
    public float moveSpeed = 5f; // Adjust the speed of movement as needed
    public float rotSpeed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get input from the joystick
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;

        // Move the player
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        rb.velocity = moveDirection * moveSpeed;

        // Optional: Rotate the player to face the movement direction
        if (moveDirection != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(moveDirection);
            rb.MoveRotation(newRotation);
        }
    }
}
