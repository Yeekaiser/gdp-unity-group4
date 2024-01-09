using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureDragSound : MonoBehaviour
{
    [SerializeField]private SoundMeter sound;
    private Rigidbody rb;

    public bool isGrounded;
    [SerializeField]public float noiseMadeByDragging;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //sound = GameObject.Find("sound").GetComponent<SoundMeter>();
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
                noiseMadeByDragging = rb.velocity.magnitude * 10f;
                if (noiseMadeByDragging > 50f)   
                    noiseMadeByDragging = 50f;
                Debug.Log(noiseMadeByDragging);
                sound.MakeSound((float)noiseMadeByDragging);
                Debug.Log(sound.currentNoise);
            }
    }
}
