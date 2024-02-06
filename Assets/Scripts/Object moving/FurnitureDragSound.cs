using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureDragSound : MonoBehaviour
{
    private SoundMeter sound;
    private Rigidbody rb;
    public WinLose winLose;
    public float noiseMadeByDragging = 30f;

    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sound = GameObject.Find("Sound").GetComponent<SoundMeter>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(rb.velocity.magnitude);
        if (collision.relativeVelocity.magnitude >= 2)
        {
            Debug.Log("entered");
            //isGrounded = true;
            noiseMadeByDragging += 20;
            sound.MakeSound(noiseMadeByDragging);
            Debug.Log(sound.currentNoise);
        }
        //Debug.Log(gameObject.name + "On the Ground");

        if (sound.currentNoise >= 100)
            winLose.Lose("Dragging furniture made too much noise!");

    }
}
