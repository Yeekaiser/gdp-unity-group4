using UnityEngine;

public class CameraPan : MonoBehaviour
{
    public float panSpeed = 2f;

    private Vector2 touchStartPos;
    private bool isPanning = false;

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        // Iterate through all active touches
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            // Check for the first touch (index 0) for camera panning
            if (i == 0)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        touchStartPos = touch.position;
                        isPanning = true;
                        break;

                    case TouchPhase.Moved:
                        if (isPanning)
                        {
                            Vector2 delta = touch.position - touchStartPos;
                            PanCamera(delta);
                        }
                        break;

                    case TouchPhase.Ended:
                        isPanning = false;
                        break;
                }
            }
            // You can add more conditions for additional touches if needed
            // else if (i == 1) { /* Handle the second touch */ }
        }
    }

    void PanCamera(Vector2 delta)
    {
        // Adjust the camera's position based on the pan speed and delta movement
        transform.Translate(-delta.x * panSpeed * Time.deltaTime, 0f, -delta.y * panSpeed * Time.deltaTime);
    }
}
