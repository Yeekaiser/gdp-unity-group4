using UnityEngine;

public class ObjectPositionScript : MonoBehaviour
{
    public Transform startingPosition;
    public Transform targetPosition;

    void Start()
    {
        if (startingPosition == null)
        {
            Debug.LogError("Starting position is not assigned in " + gameObject.name);
        }

        if (targetPosition == null)
        {
            Debug.LogError("Target position is not assigned in " + gameObject.name);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StartingArea"))
        {
            // Object entered the starting area
            Debug.Log("Object entered the starting area: " + gameObject.name);
        }

        if (other.CompareTag("TargetArea"))
        {
            // Object entered the target area
            Debug.Log("Object entered the target area: " + gameObject.name);

            // You can implement additional logic here when the object reaches the target
        }
    }
}
