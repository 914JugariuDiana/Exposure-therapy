using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float mouseSensitivity = 2.0f;
    float cameraVerticalRotation = 0f;
    public Transform orientation;
    public Transform player;

    bool lockedCursor = true;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Mouse X");
        float inputY = Input.GetAxisRaw("Mouse Y");


        cameraVerticalRotation -= inputY;
        float yRotation = cameraVerticalRotation;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 50f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

        //transform.rotation = Quaternion.Euler(yRotation, cameraVerticalRotation, 0);
        //orientation.rotation = Quaternion.Euler(0, cameraVerticalRotation, 0);

        player.Rotate(Vector3.up * inputX);
    }
}
