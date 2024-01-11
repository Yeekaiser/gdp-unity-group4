using System.Collections;
using UnityEngine;

public class FriendScript : MonoBehaviour
{
    public int scenario = 0;

    [SerializeField] private Transform startPos;
    [SerializeField] private Transform doorOutsidePos;
    [SerializeField] private Transform doorInsidePos;
    [SerializeField] private Transform chairPos;
    [SerializeField] private Transform beforeLeaveDoorPos;
    [SerializeField] private Transform leaveDoorPos;

    [SerializeField] private float moveSpeed = 5f; // Adjust the speed as needed

    private Vector3 targetPosition;

    // Update is called once per frame
    void Update()
    {
        switch (scenario)
        {
            case 6:
                MoveToPosition(leaveDoorPos.position);
                print("Why hello there good sir! Let me teach you about Trigonometry!");
                break;
            case 5:
                MoveToPosition(beforeLeaveDoorPos.position);
                print("Why hello there good sir! Let me teach you about Trigonometry!");
                break;
            case 4:
                MoveToPosition(chairPos.position);
                print("Hello and good day!");
                break;
            case 3:
                MoveToPosition(doorInsidePos.position);
                print("Whadya want?");
                break;
            case 2:
                MoveToPosition(doorOutsidePos.position);
                print("Grog SMASH!");
                break;
            case 1:
                MoveToPosition(startPos.position);
                print("Ulg, glib, Pblblblblb");
                break;
            default:
                print("Incorrect intelligence level.");
                break;
        }
    }

    void MoveToPosition(Vector3 targetPosition)
    {
        // Interpolate towards the target position gradually
        transform.position = Vector3.Lerp(transform.position, new Vector3(targetPosition.x, gameObject.transform.position.y, targetPosition.z), moveSpeed * Time.deltaTime);
    }
}
