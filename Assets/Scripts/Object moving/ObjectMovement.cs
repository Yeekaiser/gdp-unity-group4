using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    void Update()
    {
        if (Input.GetMouseButton(0)) // Check for left mouse button
        {
            MoveObjectWithMouse();
        }
    }

    void MoveObjectWithMouse()
    {
        // Get the current mouse position in world space
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z; // Maintain the object's z-coordinate

        // Move the object towards the mouse position
        transform.position = Vector3.Lerp(transform.position, mousePos, moveSpeed * Time.deltaTime);
    }
}

