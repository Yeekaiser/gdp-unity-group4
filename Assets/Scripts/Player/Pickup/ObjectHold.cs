using UnityEngine;

public class ObjectHold : MonoBehaviour
{
    public GameObject Object;
    public Transform PlayerTransform;
    public float range = 3f;
    public Camera Camera;

    private bool isHolding = false;
    private Collider objectCollider;

    void Start()
    {
        objectCollider = Object.GetComponent<Collider>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && !isHolding)
        {
            StartPickUp();
        }

        if (Input.GetKeyUp(KeyCode.Mouse1) && isHolding)
        {
            Drop();
        }
    }

    void StartPickUp()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                PickUp();
            }
        }
    }

    void PickUp()
    {
        Object.transform.SetParent(Camera.transform);
        objectCollider.enabled = false; // Disable the collider when picked up
        Object.GetComponent<Rigidbody>().isKinematic = true; // Disable physics interactions for the held object
        isHolding = true;
    }

    void Drop()
    {
        Object.transform.SetParent(null); // Set the object's parent back to null
        objectCollider.enabled = true; // Enable the collider when dropped
        Object.GetComponent<Rigidbody>().isKinematic = false; // Enable physics interactions
        isHolding = false;
    }
}

