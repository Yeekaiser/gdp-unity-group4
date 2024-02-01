using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ObjectHold : MonoBehaviour
{
    public GameObject[] ObjectArray;
    //[HideInInspector] public GameObject Object;
    public Transform PlayerTransform;
    public float range = 3f;
    public Camera Camera;

    public bool isHolding = false;

    //public Collider[] colliders;
    //public Collider objectCollider;

    void Start()
    {
        //colliders = new Collider[ObjectArray.Length];

        //for (int i = 0; i < ObjectArray.Length; i++)
        //{
        //    colliders[i] = ObjectArray[i].GetComponent<Collider>();
        //}
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Mouse1) && !isHolding)
        //{
        //    StartPickUp();
        //}

        //if (Input.GetKeyUp(KeyCode.Mouse1) && isHolding)
        //{
        //    Drop();
        //}
        if(Input.GetKeyUp(KeyCode.E))
        {
            TogglePickUp();
        }
    }

    public void TogglePickUp()
    {
        Debug.Log("Called");
        RaycastHit hit;
        if(Camera.transform.childCount == 0)
        {
            if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range))
            {
                //Debug.Log(hit.transform.name);

                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    PickUp(target);
                    return;
                }
            }
        }
        Drop();
    }

    void PickUp(Target target)
    {
        Debug.Log("pickup called");

        GameObject Object = target.gameObject;
        Object.transform.SetParent(Camera.transform);
        target.GetComponent<Collider>().enabled = false; // Disable the collider when picked up
        Object.GetComponent<Rigidbody>().isKinematic = true; // Disable physics interactions for the held object
        isHolding = true;
    }

    void Drop()
    {
        Debug.Log("drop called");

        GameObject Object = Camera.transform.GetChild(0).gameObject;
        Object.transform.SetParent(null); // Set the object's parent back to null
        Object.GetComponent<Collider>().enabled = true; // Enable the collider when dropped
        Object.GetComponent<Rigidbody>().isKinematic = false; // Enable physics interactions
        isHolding = false;
    }
}

