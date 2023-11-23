using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    SoundMeter soundMeter;
    public float doorOpenDelay = 15f;
    public float noiseMadeByDoorSlam;
    public float timeToFullyOpenDoor;
    public bool doorIsOpen;
    public bool doorFinishedOpening;
    public float noiselevel;
    public float playervel = 0f;



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
        InvokeRepeating("DoorOpen", 0f, doorOpenDelay);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void DoorOpen()
    {
        if (!doorIsOpen)
        {
            anim.SetTrigger("doorOpen");
            doorIsOpen = true;
        }
        else
        {
            if (doorFinishedOpening)
            {
                //set noise levels up
                //noiseScript.noiseLevel += noiseMadeByDoorSlam;
                anim.SetTrigger("doorClose");
                doorIsOpen = false;
            }

        }

    }

    void DoorClose()
    {
        //play audio
        //set noise level up
        //SoundMeter.currentNoise += noiseMadeByDoorSlam;
        anim.SetTrigger("doorClose");
        doorIsOpen = false;
        if (playervel >= 50)
            {
            soundMeter.currentNoise += 10;
        }
    }
}
