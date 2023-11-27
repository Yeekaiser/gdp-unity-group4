using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureDragSound : MonoBehaviour
{
    SoundMeter sound;
    public Rigidbody rb;

    private bool isGrounded;
    public float noiseMadeByDragging;

    // Start is called before the first frame update
    void Start()
    {

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
                sound.currentNoise += noiseMadeByDragging;
            }
    }
}
