using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Variables")]
    public int moveSpeed;
    public Rigidbody2D rb;
    public Vector2 moveInput;

    [Header("Interact Variables")]
    public bool interactPhase = false;


    private void Update()
    {
        if (interactPhase == true)
        {
            interactPhase = false;
            TryInteract();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = moveInput.normalized * moveSpeed;
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            interactPhase = true;
        }
    }

    private void TryInteract()
    {
        print("Try Interact");
    }
}
