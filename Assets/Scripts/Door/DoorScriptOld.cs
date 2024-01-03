using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScriptOld : MonoBehaviour
{
    [SerializeField]
    private SoundMeter sound;
    public float noiseMadeByDoorSlam;

    public float doorSlamDelay = 15f;
    public float timeToFullyOpenDoor;

    public bool doorIsOpen = false;
    public bool doorFinishedOpening;
    
    public float playervel = 0f;
    public float openSpeed = -5f;
    public float closeSpeed = 180f;

    new private HingeJoint hingeJoint;
    public float targetRotation = -90f;
    public float originalRotation = 0f;

    [HideInInspector]
    public float timePassed;
    [HideInInspector]
    public float doorOpenedTime;
    [HideInInspector]
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();
        anim = GetComponent<Animator>();
        //InvokeRepeating("DoorState", 0f, doorOpenDelay);    //calls DoorState() every doorOpenDelay seconds - door will either slam or open every 10 sec
    }

    // Update is called once per frame
    void Update()
    {
        DoorState();
    }

    void DoorState()
    {
        //Debug.Log("doorState called");
        Debug.Log("hingejoint angle = " + hingeJoint.angle);
        if (hingeJoint.angle >= 0)
        {
            DoorStartToOpen();
        }
        else if(hingeJoint.angle == -90)
        {
            //Invoke("DoorSlamClose", doorSlamDelay);
            DoorSlamClose();
        }
    }

    void DoorStartToOpen()
    {
        Debug.Log("DoorStartToOpen called");
        DoorRotate();
        doorIsOpen = true;
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

    void DoorRotate()
    {

        Debug.Log("DoorRotate called");

        JointMotor motor = hingeJoint.motor;
        motor.targetVelocity = openSpeed;
        hingeJoint.motor = motor;

        //float angleDifference = targetRotation - hingeJoint.angle;
        //Debug.Log("hingeJoint angle is " + hingeJoint.angle);
        ////Debug.Log("targetRotation is " + targetRotation);

        //JointMotor motor = hingeJoint.motor;

        //motor.targetVelocity = Mathf.Sign(angleDifference) * rotSpeed;
        //hingeJoint.motor = motor;
        //if (hingeJoint.angle == -90)
        //{
        //    doorFinishedOpening = true;
        //}
    }
}