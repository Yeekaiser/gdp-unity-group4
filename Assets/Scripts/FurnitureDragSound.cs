using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureDragSound : MonoBehaviour
{
    SoundMeter soundMeter;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        //isGrounded = Physics.BoxCast(Vector3.zero, );
    }

    // Update is called once per frame
    void Update()
    {
        float maxDistance = 10f;
        RaycastHit hit;

        isGrounded = Physics.BoxCast(transform.position, transform.lossyScale/2, transform.forward, out hit, transform.rotation, maxDistance, 3);
        if (isGrounded)
            Debug.Log("On the Ground");
    }

    private void OnDrawGizmos()
    {
        
    }
}
