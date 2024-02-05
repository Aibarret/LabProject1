using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaterCont : MonoBehaviour
{
    [Header("Object Refs")]
    public GameObject gun;

    [Header("Movement")]
    public float speed;
    public float sensitivity;
    public float sprintSpeed;

    private float moveFB;
    private float moveLR;
    private float rotX;
    private float roty;
    private Weapon gunScript;
    private CharacterController cc;
    private Camera cam;

    [Header("Gun Settings")]
    [SerializeField] private int currentAmmo;
    [SerializeField] private C4 c4;

    [Header("Inventory")]
    public int inventoryIndex;
    private List<InventoryItem> inventory = new List<InventoryItem>();

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cc = gameObject.GetComponent<CharacterController>();
        cam = gameObject.transform.GetChild(0).GetComponent<Camera>();
        gunScript = gun.GetComponent<Weapon>();
    }

    private void FixedUpdate()
    {
/*        if (Input.GetKey(KeyCode.Tab))
        {
            Cursor.lockState = CursorLockMode.None;
        }*/

        if (Input.GetMouseButtonDown(0))
        {
            gunScript.Shoot();
        }

        if (Input.GetMouseButtonDown(1))
        {
            currentAmmo = gunScript.Reload(currentAmmo);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inventory.Count > 0)
            {
                inventory[inventoryIndex].Activate();
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            inventoryIndex += 1;
            if (inventoryIndex >= inventory.Count)
            {
                inventoryIndex = 0;
            }
        }

        Move();
    }




    public void AddToInventory(InventoryItem item)
    {
        if (!inventory.Contains(item))
        {
            print("Added " + item + " to inventory");
            inventory.Add(item);
        }
    }

    public void PickUpAmmo(int amount)
    {
        currentAmmo += amount;
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

        Vector3 movement = new Vector3(moveLR, 0, moveFB).normalized * movementSpeed;

        transform.Rotate(0, rotX, 0);
        cam.transform.localRotation = Quaternion.Euler(roty, 0, 0);

        movement = transform.rotation * movement;
        cc.Move(movement * Time.deltaTime);
    }
}
