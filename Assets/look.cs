using UnityEngine;

public class look : MonoBehaviour
{
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;

    Camera cam;

    float xRotation;
    float yRotation;

    private void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        // Update camera and player rotation here
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
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
