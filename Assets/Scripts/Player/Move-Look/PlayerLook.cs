using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    //public RectTransform panelRect;
    public Canvas canvas;

    [SerializeField] private float sensX;
    [SerializeField] private float sensY;

    Camera cam;

    float mouseX;
    float mouseY;

    float multiplier = 0.01f;

    float xRotation;
    float yRotation;

    private void Start()
    {
        cam = GetComponentInChildren<Camera>();

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    private void Update()
    {
        //if (RectTransformUtility.RectangleContainsScreenPoint(panelRect, canvas.gameObject.transform.position))
        //{
            MyInput();

            cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            transform.rotation = Quaternion.Euler(0, yRotation, 0);
        //}
    }

    void MyInput()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        if (Input.mousePosition.x > Screen.width / 2)
        {
            yRotation += mouseX * sensX * multiplier;
            xRotation -= mouseY * sensY * multiplier;

            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        }
    }
}
