using UnityEngine;

public class JoystickMove1 : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private Rigidbody rb;

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

        // Transform local movement to world space and set the velocity
        rb.velocity = transform.TransformDirection(localMoveDirection) * moveSpeed;

        // Uncomment the following lines if you want to rotate based on velocity
        // if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        // {
        //     transform.rotation = Quaternion.LookRotation(rb.velocity);
        // }
    }
}
