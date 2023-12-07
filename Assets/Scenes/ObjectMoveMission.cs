using UnityEngine;

public class ObjectMoveMission : MonoBehaviour
{
    public Transform[] objectsToMove;
    public Collider[] startingAreas;
    public Collider[] targetAreas;

    private int movedObjectsCount = 0;

    void OnTriggerEnter(Collider other)
    {
        // Check if the entered object is in both starting and target areas
        for (int i = 0; i < objectsToMove.Length; i++)
        {
            if (startingAreas[i].gameObject == other.gameObject && !objectsToMove[i].GetComponent<ObjectInfo>().IsMoved)
            {
                // Object entered the starting area
                Debug.Log("Object entered the starting area: " + other.gameObject.name);
            }

            if (targetAreas[i].gameObject == other.gameObject && objectsToMove[i].GetComponent<ObjectInfo>().IsMoved)
            {
                // Object entered the target area after being moved
                Debug.Log("Object entered the target area: " + other.gameObject.name);
                objectsToMove[i].GetComponent<ObjectInfo>().IsMoved = true;
                movedObjectsCount++;

                // Check for mission completion
                if (movedObjectsCount == objectsToMove.Length)
                {
                    Debug.Log("Mission Completed!");
                    // Implement mission completion actions
                }
            }
        }
    }
}
