using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDoorScript : MonoBehaviour
{
    public HingeJoint hinge;
    public JointMotor motor;
    private float targetVel = 3000f;
    private float closeForce = 600f;

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

    }

    private void DoorSlamClose()
    {
        Debug.Log("Doorslamclose called");

        motor = hinge.motor;
        motor.targetVelocity = targetVel;
        motor.force = closeForce;
        hinge.motor = motor;


        doorSlamCalled = false;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Doorslam")
            sound.MakeSound(noiseMade);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided");
        if (other.gameObject.name == "Doorslam")
            sound.MakeSound(noiseMade);

        if (other.gameObject.name == "Doorslam")
            sound.MakeSound(noiseMade);

        motor = hinge.motor;
        motor.targetVelocity = 0f;
        hinge.motor = motor;
    }

}
