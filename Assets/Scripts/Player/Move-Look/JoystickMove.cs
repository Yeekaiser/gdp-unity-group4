using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class JoystickMove : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private Rigidbody rb;
    float movementMultiplier = 10f;


    float horizontalMovement;
    float verticalMovement;

    Vector3 moveDirection;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        //MyInput();
        //ControlDrag();
    }

    void MyInput()
    {
        //horizontalMovement = Input.GetAxisRaw("Horizontal");
        //verticalMovement = Input.GetAxisRaw("Vertical");

        //moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
    }

    void ControlDrag()
    {
        rb.drag = 6f;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        
        rb.velocity = new Vector3(joystick.Horizontal * moveSpeed, rb.velocity.y, joystick.Vertical * moveSpeed);
        rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
        //if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        //{
        //    transform.rotation = Quaternion.LookRotation(rb.velocity);
        //}
    }
}