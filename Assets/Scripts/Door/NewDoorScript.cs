using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDoorScript : MonoBehaviour
{
    public HingeJoint hinge;
    public JointMotor motor;
    private float targetVel = 3000f;
    private float closeForce = 600f;

    bool doorSlamCalled;
    bool doorSlamNoise = false;

    [SerializeField] private SoundMeter sound;
    [SerializeField] public float noiseMade = 300f;

    [SerializeField] private FriendScript scenario;
    [SerializeField]private WinLose winLose;

    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void DoorLoseCondition()
    {
        if(scenario.scenario == 3)
        {
            Debug.Log("Doorslamclose called");

            motor = hinge.motor;
            motor.targetVelocity = targetVel;
            motor.force = closeForce;
            hinge.motor = motor;

            doorSlamCalled = false;
            doorSlamNoise = true;

            sound.MakeSound(100);
            winLose.Lose("Wind slammed the door loudly!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggered");
        if (other.gameObject.name == "Doorslam")
            scenario.nextScenario(scenario.scenario, 4);

        motor = hinge.motor;
        motor.targetVelocity = 0f;
        hinge.motor = motor;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            StartCoroutine(PauseForSecondsSlam(15));
            scenario.nextScenario(scenario.scenario, 3);
        }
    }

    IEnumerator PauseForSecondsSlam(int seconds)
    {
        // Pause for x seconds
        yield return new WaitForSeconds(seconds);

        DoorLoseCondition();
    }


}
