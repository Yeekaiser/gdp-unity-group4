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

    [SerializeField] private GameObject Dialogue1;
    [SerializeField] private GameObject Dialogue2;
    [SerializeField] private GameObject Dialogue3;
    [SerializeField] private GameObject Dialogue4;
    [SerializeField] private GameObject Dialogue5;
    
    [SerializeField] private float moveSpeed = 5f; // Adjust the speed as needed

    private Vector3 targetPosition;

    // Update is called once per frame
    void Update()
    {
        switch (scenario)
        {
            case 6:
                MoveToPosition(leaveDoorPos.position);
                
                break;
            case 5:
                MoveToPosition(beforeLeaveDoorPos.position);
                Dialogue4.SetActive(false);
                Dialogue5.SetActive(true);
                break;
            case 4:
                MoveToPosition(chairPos.position);
                Dialogue3.SetActive(false);
                Dialogue4.SetActive(true);
                break;
            case 3:
                MoveToPosition(doorInsidePos.position);
                Dialogue2.SetActive(false);
                Dialogue3.SetActive(true);
                break;
            case 2:
                MoveToPosition(doorOutsidePos.position);
                Dialogue1.SetActive(false);
                Dialogue2.SetActive(true);

                break;
            case 1:
                MoveToPosition(startPos.position);
                Dialogue1.SetActive(true);

                break;
            default:
                break;
        }
    }

    void MoveToPosition(Vector3 targetPosition)
    {
        // Interpolate towards the target position gradually
        transform.position = Vector3.Lerp(transform.position, new Vector3(targetPosition.x, gameObject.transform.position.y, targetPosition.z), moveSpeed * Time.deltaTime);
    }
}
