using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureDragSound : MonoBehaviour
{
    public SoundMeter sound;
    public Rigidbody rb;

    public bool isGrounded;
    public float noiseMadeByDragging;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float maxDistance = 10f;
        RaycastHit hit;

        isGrounded = Physics.BoxCast(transform.position, transform.lossyScale/2, transform.forward, out hit, transform.rotation, maxDistance, 3);
        if(rb.velocity.magnitude >= 1)
            if (isGrounded)
            {   
                Debug.Log(gameObject.name + "On the Ground");
                noiseMadeByDragging = rb.velocity.magnitude * 3f;
                if (noiseMadeByDragging > 10)   
                    noiseMadeByDragging = 10;
                sound.currentNoise += noiseMadeByDragging * Time.deltaTime;
                Debug.Log(sound.currentNoise);
            }
    }
}
