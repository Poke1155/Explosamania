using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputActionMap actionMap;
    private InputAction movement;
    private Vector2 movementInput;
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private Bullet bullet;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        movement = playerInput.actions["Movement"];

        movement.performed += OnMovement;
        movement.canceled += OnMovementCanceled;
    }
    

    private void FixedUpdate()
    {
        if (movementInput != Vector2.zero)
        {
            Vector3 movementDirection = new Vector3(movementInput.x, movementInput.y, 0f);
            transform.position += movementDirection * movementSpeed * Time.deltaTime;
        }
    }
    
    private void OnMovement(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    
    private void OnMovementCanceled(InputAction.CallbackContext obj)
    {
        movementInput = Vector2.zero;
    }
    
    
}