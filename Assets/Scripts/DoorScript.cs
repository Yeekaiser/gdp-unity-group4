using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    SoundMeter soundMeter;
    public float doorOpenDelay = 15f;
    public float noiseMadeByDoorSlam;
    public float doorFullyOpenTime;
    public bool doorIsOpen = false;
    public bool doorFinishedOpening;
    public float noiselevel;
    public float playervel = 0f;

    SoundMeter sound;


    [HideInInspector]
    public float timePassed;
    [HideInInspector]
    public float doorOpenedTime;


    [HideInInspector]
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //timeToFullyOpenDoor = anim.time
        InvokeRepeating("DoorState", 0f, doorOpenDelay);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void DoorState()
    {
        if (doorIsOpen == false)
        {
            DoorStartToOpen();
        }
        else
        {
            DoorSlamClose();
        }
    }

    void DoorStartToOpen()
    {
        anim.SetTrigger("doorOpen");
        doorIsOpen = true;
        if (timePassed >= doorFullyOpenTime) 
        {
            doorFinishedOpening = true;
        }
    }

    void DoorSlamClose()
    {
        //play audio
        //set noise level up
        sound.currentNoise += noiseMadeByDoorSlam;
        anim.SetTrigger("doorClose");
        doorIsOpen = false;
        if (playervel >= 50)
            {
            soundMeter.currentNoise += 10;
        }
    }
}
