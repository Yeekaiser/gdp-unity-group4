using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForward : MonoBehaviour
{
    public bool isWalking = false;
    private Rigidbody rb;
    public int walkSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking == true)
        {
            Walk();
        }
        else
        {
            StopWalk();
        }
    }

    public void ToggleWalk()
    {
        // Toggle the walk state
        isWalking = !isWalking;


    }

    void Walk()
    {
        rb.velocity = transform.forward * walkSpeed;
    }

    void StopWalk()
    {
        rb.velocity = Vector3.zero;
    }
}
