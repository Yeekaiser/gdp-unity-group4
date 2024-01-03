using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public Transform target; // Assign the target position in the Unity Editor
    public float speed = 1.0f; // Speed of the movement
    public float waitTime = 2.0f; // Time to wait at the target position

    private Vector3 startPosition;
    private float waitTimer;
    private enum State { MovingToTarget, Waiting, MovingBack }
    private State currentState;

    private void Start()
    {
        startPosition = transform.position; // Save the original position
        currentState = State.MovingToTarget;
        waitTimer = waitTime;
    }

    private void Update()
    {
        switch (currentState)
        {
            case State.MovingToTarget:
                MoveTowards(target.position);
                if (Vector3.Distance(transform.position, target.position) < 0.01f)
                {
                    currentState = State.Waiting;
                }
                break;
            case State.Waiting:
                waitTimer -= Time.deltaTime;
                if (waitTimer <= 0)
                {
                    currentState = State.MovingBack;
                    waitTimer = waitTime; // Reset the timer for future use
                }
                break;
            case State.MovingBack:
                MoveTowards(startPosition);
                if (Vector3.Distance(transform.position, startPosition) < 0.01f)
                {
                    // Optional: Reset to initial state if you want this behavior to repeat
                    currentState = State.MovingToTarget;
                }
                break;
        }
    }

    private void MoveTowards(Vector3 destination)
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
    }
}
