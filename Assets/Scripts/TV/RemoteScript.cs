using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.tvOS;

public class RemoteScript : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject remoteui;
    // Start is called before the first frame update
    void Start()
    {
        remoteui.SetActive(false);
        

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent == cam.transform)
            remoteui.SetActive(true);
        else
            remoteui.SetActive(false);
            
    }
}
