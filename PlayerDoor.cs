using System.Collections;
using UnityEngine;

public class PlayerDoor : MonoBehaviour
{
    public GameObject door;
    public KeyCode interactKey = KeyCode.E;

    private FixedJoint joint;
    private bool isInteracting = false;

    void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            if (isInteracting)
            {
                StopInteraction();
            }
            else
            {
                StartInteraction();
            }
        }

        if (isInteracting)
        {
            MoveDoorWithPlayer();
        }
    }

    void StartInteraction()
    {
        if (door != null)
        {
            joint = door.AddComponent<FixedJoint>();
            joint.connectedBody = GetComponent<Rigidbody>();
            isInteracting = true;
        }
    }

    void StopInteraction()
    {
        if (joint != null)
        {
            Destroy(joint);
            isInteracting = false;
        }
    }

    void MoveDoorWithPlayer()
    {
        Vector3 force = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        force *= 10f; 
        door.GetComponent<Rigidbody>().AddForce(force);
    }
}