using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaterCont : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public float sensitivity;
    public float sprintSpeed;

    private float moveFB;
    private float moveLR;
    private float rotX;
    private float roty;
    private CharacterController cc;
    private Camera cam;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cc = gameObject.GetComponent<CharacterController>();
        cam = gameObject.transform.GetChild(0).GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        Move();
    }

    public void Move()
    {
        float movementSpeed = speed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = sprintSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movementSpeed = speed;
        }

        moveFB = Input.GetAxis("Vertical") * movementSpeed;
        moveLR = Input.GetAxis("Horizontal") * movementSpeed;

        rotX = Input.GetAxis("Mouse X") * sensitivity;
        roty -= Input.GetAxis("Mouse Y") * sensitivity;

        roty = Mathf.Clamp(roty, -60f, 60f);

        Vector3 movement = new Vector3(moveLR, 0, moveFB);

        transform.Rotate(0, rotX, 0);
        cam.transform.localRotation = Quaternion.Euler(roty, 0, 0);

        movement = transform.rotation * movement;
        cc.Move(movement * Time.deltaTime);
    }
}
