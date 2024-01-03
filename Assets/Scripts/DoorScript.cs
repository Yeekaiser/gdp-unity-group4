using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField]
    private SoundMeter sound;
    public float noiseMadeByDoorSlam;

    public float doorSlamDelay = 15f;
    public float timeToFullyOpenDoor;

    public bool doorIsOpen = false;
    public float doorFistOpenedTime;
    //public bool doorFinishedOpening;

    [SerializeField] private GameObject player;
    private Rigidbody playerRB;
    public float playervel = 10f;
    public float openSpeed = -5f;
    public float closeSpeed = 180f;

    new private HingeJoint hingeJoint;
    public float targetRotation = -90f;
    public float originalRotation = 0f;

    [HideInInspector]
    public float timePassed;
    [HideInInspector]
    public float doorOpenedTime;

    private bool DoorSlamCalled;
    // Start is called before the first frame update
    void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();   
        playerRB = player.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(hingeJoint.angle <= -80 && DoorSlamCalled != true)
        {
            DoorSlamClose();
            DoorSlamCalled = true;
        }
        else if (hingeJoint.angle >= 0)
        {
            DoorSlamCalled = false;
            Debug.Log(playerRB.velocity.magnitude + "is player vel");
            if (playerRB.velocity.magnitude > playervel)
            {
                DoorSlamClose();
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collided with door");
        Invoke("DoorCheck", 10f);
    }

    private void DoorCheck()
    {
        //Debug.Log("Doorcheck called" + hingeJoint.angle);
        if (hingeJoint.angle < -5)
        {
            DoorStartOpening();
            //Debug.Log("second check" + hingeJoint.angle);
        }
    }

    private void DoorStartOpening()
    {
        //Debug.Log("DoorStartOpening Called");
        JointMotor motor = hingeJoint.motor;
        motor.targetVelocity = openSpeed;
        hingeJoint.motor = motor;
    }
    void DoorSlamClose()
    {
        Debug.Log("DoorSlamClose called");
        JointMotor motor = hingeJoint.motor;

        motor.targetVelocity = closeSpeed;
        hingeJoint.motor = motor;

        doorIsOpen = false;
        if (playervel >= 50)
        {
            noiseMadeByDoorSlam += 10;
            sound.currentNoise += noiseMadeByDoorSlam;
            noiseMadeByDoorSlam -= 10;
        }
        else
        {
            sound.currentNoise += noiseMadeByDoorSlam;
        }
    }


    // Update is called once per frame
    //void Update()
    //{
    //    DoorState();
    //}

    //void DoorState()
    //{
    //    //Debug.Log("doorState called");
    //    Debug.Log("hingejoint angle = " + hingeJoint.angle);
    //    if (hingeJoint.angle >= 2 && doorIsOpen != true)
    //    {
    //        Invoke("DoorStartToOpen", 5f);
    //    }
    //    else if(hingeJoint.angle == -90)
    //    {
    //        //Invoke("DoorSlamClose", doorSlamDelay);
    //        DoorSlamClose();
    //    }
    //}

    //void DoorStartToOpen()
    //{
    //    Debug.Log("DoorStartToOpen called");
    //    DoorRotate();
    //    doorIsOpen = true;
    //    doorFistOpenedTime = Time.time;
    //}


    //void DoorRotate()
    //{

    //    Debug.Log("DoorRotate called");

    //    JointMotor motor = hingeJoint.motor;
    //    motor.targetVelocity = openSpeed;
    //    hingeJoint.motor = motor;

    //    //float angleDifference = targetRotation - hingeJoint.angle;
    //    //Debug.Log("hingeJoint angle is " + hingeJoint.angle);
    //    ////Debug.Log("targetRotation is " + targetRotation);

    //    //JointMotor motor = hingeJoint.motor;

    //    //motor.targetVelocity = Mathf.Sign(angleDifference) * rotSpeed;
    //    //hingeJoint.motor = motor;
    //    //if (hingeJoint.angle == -90)
    //    //{
    //    //    doorFinishedOpening = true;
    //    //}
    //}
}