using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float jumpPower = 7f;
    public float gravity = 10f;

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0f;
    public bool canMove = true;

    CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float curSpeedx = canMove ? walkSpeed * Input.GetAxis("Vertical") : 0f;
        float curSpeedy = canMove ? walkSpeed * Input.GetAxis("Horizontal") : 0f;

        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedx) + (right * curSpeedy);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        } else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.Translate(Vector3.forward * Time.deltaTime * speed);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.Translate(-1 * Vector3.forward * Time.deltaTime * speed);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Rotate(0, -1, 0);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Rotate(0, 1, 0);
        //}
    }
}
