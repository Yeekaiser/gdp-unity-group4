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
    [SerializeField] private GameObject Dialogue6;
    
    [SerializeField] private float moveSpeed = 5f; // Adjust the speed as needed

    private Vector3 targetPosition;

    [SerializeField] private WinLose winLose;

    // Update is called once per frame
    void Update()
    {
        switch (scenario)
        {
            case 7:
                MoveToPosition(leaveDoorPos.position);
                
                break;
            case 6: //this is after watching TV, friend about to leave
                    //moves to 6 by opening and closing the door quietly
                MoveToPosition(beforeLeaveDoorPos.position);
                Dialogue4.SetActive(false);
                Dialogue5.SetActive(true);
                StartCoroutine(PauseForSeconds(4));
                winLose.Win();
                break;
            case 5: //this is after the chair is in position, starting to watch TV
                    //moves to 5 by TVScript after keeping tv volume down for 10 seconds
                MoveToPosition(chairPos.position);
                Dialogue4.SetActive(false);
                Dialogue5.SetActive(true);
                break;
            case 4: //this is after door is closed
                    //moves to 4 by ObjectPositionScript after moving chair to correct position
                MoveToPosition(doorInsidePos.position);
                Dialogue3.SetActive(false);
                Dialogue4.SetActive(true);
                break;
            case 3: //this is after friend steps foot inside house
                    //changes dialogue to 4 after door is closed
                MoveToPosition(doorInsidePos.position);
                Dialogue2.SetActive(false);
                Dialogue3.SetActive(true);
                break;
            case 2: //this is beginning of quests
                    //moves to 3 by NewDoorScript when door is open
                MoveToPosition(doorOutsidePos.position);
                Dialogue1.SetActive(false);
                Dialogue2.SetActive(true);
                break;
            case 1: //this is starting, friend says hi
                MoveToPosition(startPos.position);
                Dialogue1.SetActive(true);
                StartCoroutine(PauseForSeconds(3));
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

    public void nextScenario(int current, int next)
    {
        if (current == next - 1)
        {
            scenario = next;
        }
    }

    IEnumerator PauseForSeconds(int seconds)
    {
        // Pause for x seconds
        yield return new WaitForSeconds(seconds);
        nextScenario(scenario, 2);
    }
}
