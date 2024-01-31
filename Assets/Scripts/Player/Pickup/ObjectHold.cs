using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ObjectHold : MonoBehaviour
{
    public GameObject[] ObjectArray;
    //[HideInInspector] public GameObject Object;
    public Transform PlayerTransform;
    public float range = 3f;
    public Camera Camera;

    private bool isHolding = false;

    private Collider[] colliders;
    private Collider objectCollider;

    void Start()
    {
        colliders = new Collider[ObjectArray.Length];

        for (int i = 0; i < ObjectArray.Length; i++)
        {
            colliders[i] = ObjectArray[i].GetComponent<Collider>();
        }
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
    }

    public void StartPickUp()
    {
        Debug.Log("Called");
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                PickUp(target);
                return;
            }
            Drop(target);
        }
    }

    void PickUp(Target target)
    {
        GameObject Object = target.gameObject;
        Object.transform.SetParent(Camera.transform);
        objectCollider.enabled = false; // Disable the collider when picked up
        Object.GetComponent<Rigidbody>().isKinematic = true; // Disable physics interactions for the held object
        isHolding = true;
    }

    void Drop(Target target)
    {
        GameObject Object = target.gameObject;
        Object.transform.SetParent(null); // Set the object's parent back to null
        objectCollider.enabled = true; // Enable the collider when dropped
        Object.GetComponent<Rigidbody>().isKinematic = false; // Enable physics interactions
        isHolding = false;
    }
}

