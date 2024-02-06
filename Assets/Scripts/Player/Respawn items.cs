using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawnitems : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 resetPosition = collision.transform.position;
        resetPosition.y = 10f;
        collision.transform.position = resetPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 resetPosition = other.transform.position;
        resetPosition.y = 10f;
        other.transform.position = resetPosition;
    }
}
