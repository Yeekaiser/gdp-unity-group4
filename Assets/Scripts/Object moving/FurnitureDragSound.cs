using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureDragSound : MonoBehaviour
{
    private SoundMeter sound;
    private Rigidbody rb;

    public bool isGrounded;
    public float noiseMadeByDragging = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sound = GameObject.Find("Sound").GetComponent<SoundMeter>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.magnitude >= 1)
            if (isGrounded)
            {   
                //Debug.Log(gameObject.name + "On the Ground");
                noiseMadeByDragging = rb.velocity.magnitude * 10f;
                if (noiseMadeByDragging > 50f)   
                    noiseMadeByDragging = 50f;

                //Debug.Log(noiseMadeByDragging);
                sound.MakeSound(noiseMadeByDragging);
                //Debug.Log(sound.currentNoise);
            }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "floor")
            isGrounded = true;
        Debug.Log(gameObject.name + "On the Ground");
    }
}
