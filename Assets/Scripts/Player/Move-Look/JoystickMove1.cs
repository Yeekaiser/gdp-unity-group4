using UnityEngine;

public class JoystickMove1 : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private RectTransform panelRect;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        // Get the local movement direction based on joystick input
        Vector3 localMoveDirection = new Vector3(joystick.Horizontal, 0f, joystick.Vertical);
        localMoveDirection.Normalize();

        // Check if joystick is within the panel boundaries
        if (RectTransformUtility.RectangleContainsScreenPoint(panelRect, joystick.gameObject.transform.position))
        {
            // Log statement to check if the condition is met
            //Debug.Log("Joystick is within the panel!");

            // Transform local movement to world space and set the velocity
            rb.velocity = transform.TransformDirection(localMoveDirection) * moveSpeed;

            // Uncomment the following lines if you want to rotate based on velocity
            // if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            // {
            //     transform.rotation = Quaternion.LookRotation(rb.velocity);
            // }
        }
        else
        {
            // Log statement to check if the condition is not met
            Debug.Log("Joystick is outside the panel!");

            // If joystick is outside the panel, stop the player
            rb.velocity = Vector3.zero;
        }
    }

}
