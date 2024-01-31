using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Look Controls")]
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;
    private Camera cam;
    private float xRotation;
    private float yRotation;

    [Header("Movement Controls")]
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private FixedJoystick movementJoystick;
    private Rigidbody rb;

    private void Start()
    {
        cam = GetComponentInChildren<Camera>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        // Handle camera rotation
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    private void FixedUpdate()
    {
        // Handle player movement
        MovePlayer();
    }

    private void MovePlayer()
    {
        // Get the local movement direction based on joystick input
        Vector3 localMoveDirection = new Vector3(movementJoystick.Horizontal, 0f, movementJoystick.Vertical);
        localMoveDirection.Normalize();

        // Transform local movement to world space and set the velocity
        rb.velocity = transform.TransformDirection(localMoveDirection) * moveSpeed;
    }

    // Call these methods from your D-pad buttons
    public void LookUp()
    {
        xRotation -= sensY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }

    public void LookDown()
    {
        xRotation += sensY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }

    public void LookLeft()
    {
        yRotation -= sensX;
    }

    public void LookRight()
    {
        yRotation += sensX;
    }
}
