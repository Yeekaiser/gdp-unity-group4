using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private SoundMeter sound;
    public float noiseMadeByDoorSlam;

    public float doorOpenDelay = 15f;
    public float timeToFullyOpenDoor;

    public bool doorIsOpen = false;
    public bool doorFinishedOpening;
    
    public float playervel = 0f;
    public float rotSpeed = 1f;

    public float targetRotation = -90f;
    public float originalRotation = 0f;
    new private HingeJoint hingeJoint;

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
        InvokeRepeating("DoorState", 0f, doorOpenDelay);    //calls DoorState() every doorOpenDelay seconds - door will either slam or open every 10 sec
    }

    // Update is called once per frame
    void Update()
    {
        if (doorIsOpen == true)
        {
            DoorRotate();
        }
        timePassed += Time.deltaTime;
    }

    void DoorState()
    {
        Debug.Log("doorState called");
        if (doorIsOpen == false)
        {
            DoorStartToOpen();
        }
        else if(doorFinishedOpening == true)
        {
            DoorSlamClose();
        }
    }

    void DoorStartToOpen()
    {
        Debug.Log("DoorStartToOpen called");
        DoorRotate();
        //anim.SetTrigger("doorOpen");
        doorIsOpen = true;
        if (hingeJoint.angle == -90) 
        {
            doorFinishedOpening = true;
        }
    }

    void DoorSlamClose()
    {
        Debug.Log("DoorSlamClose called");
        sound.currentNoise += noiseMadeByDoorSlam;
        float angleDifference = originalRotation - hingeJoint.angle;

        JointMotor motor = hingeJoint.motor;
        motor.targetVelocity = Mathf.Sign(angleDifference) * rotSpeed;
        hingeJoint.motor = motor;

        //anim.SetTrigger("doorClose");
        doorIsOpen = false;
        if (playervel >= 50)
            {
            sound.currentNoise += 10;
        }
    }

    void DoorRotate()
    {
        Debug.Log("DoorRotate called");
        float angleDifference = targetRotation - hingeJoint.angle;

        JointMotor motor = hingeJoint.motor;
        motor.targetVelocity = Mathf.Sign(angleDifference) * rotSpeed;
        hingeJoint.motor = motor;
    }
}