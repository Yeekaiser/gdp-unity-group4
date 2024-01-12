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

    private WinLose winLose;
    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hinge.angle < 0 && doorSlamCalled == false)
        {
            Debug.Log(hinge.angle);

            StartCoroutine(PauseForSeconds(3));

            Invoke("DoorSlamClose", 15f);
            doorSlamCalled = true;
        }

        if(scenario.scenario > 3)
        {
            //JointLimits limits = GetComponent<HingeJoint>().limits;

            //// Modify the limits
            //limits.min = -5;
            //limits.max = 90;

            //// Apply the modified limits back to the HingeJoint
            //GetComponent<HingeJoint>().limits = limits;
        }
    }

    private void DoorSlamClose()
    {
        Debug.Log("Doorslamclose called");

        motor = hinge.motor;
        motor.targetVelocity = targetVel;
        motor.force = closeForce;
        hinge.motor = motor;


        doorSlamCalled = false;
        doorSlamNoise = true;

        winLose.Lose();

    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.name == "Doorslam" && doorSlamNoise == true)
    //        sound.MakeSound(noiseMade);

    //}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggered");
        if (other.gameObject.name == "Doorslam" && doorSlamNoise == true)
            sound.MakeSound(noiseMade);

        //if (other.gameObject.name == "Doorslam")
        //    sound.MakeSound(noiseMade);

        motor = hinge.motor;
        motor.targetVelocity = 0f;
        hinge.motor = motor;
    }

    IEnumerator PauseForSeconds(int seconds)
    {
        // Pause for 5 seconds
        yield return new WaitForSeconds(seconds);
        scenario.nextScenario(scenario.scenario, 3);
    }
}
