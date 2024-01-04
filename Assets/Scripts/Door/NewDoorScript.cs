using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDoorScript : MonoBehaviour
{
    public HingeJoint hinge;
    public JointMotor motor;
    private float targetVel = 180f;
    private float closeForce = 100f;

    bool doorSlamCalled = false;

    [SerializeField] private SoundMeter sound;
    [SerializeField] public float noiseMade = 10f;
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
            Invoke("DoorSlamClose", 10f);
            doorSlamCalled = true;
        }
        else
        {
            motor.force = 0f;
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

        sound.MakeSound(noiseMade);
    }

    

}
