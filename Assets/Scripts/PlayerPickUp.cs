using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    private GameObject itemInHand;
    private bool isTouching = false;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                isTouching = true;

                if (itemInHand == null)
                {
                    TryPickUpItem();
                }
                else
                {
                    DropItem();
                }
            }
        }
        else
        {
            isTouching = false;
        }
    }

    void TryPickUpItem()
    {
        if (isTouching)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 2f))
            {
                if (hit.collider.CompareTag("Item"))
                {
                    PickUpItem(hit.collider.gameObject);
                }
            }
        }
    }

    void PickUpItem(GameObject item)
    {
        itemInHand = item;
        itemInHand.transform.SetParent(transform);
        itemInHand.transform.localPosition = new Vector3(0, 1, 1); 
        itemInHand.GetComponent<Rigidbody>().isKinematic = true; 
    }

    void DropItem()
    {
        itemInHand.transform.SetParent(null);
        itemInHand.GetComponent<Rigidbody>().isKinematic = false;

        itemInHand = null;
    }

}
