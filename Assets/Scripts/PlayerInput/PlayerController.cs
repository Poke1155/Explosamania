using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private Bullet bullet;
    
    private PlayerInput playerInput;
    private InputActionMap actionMap;
    private InputAction movement;
    private Vector2 movementInput;
    public Vector2 moveDirection;
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
            Vector3 movementValue = new Vector3(movementInput.x, movementInput.y, 0f);
            transform.position += movementValue * movementSpeed * Time.deltaTime;
        }
    }
    
    private void OnMovement(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        SetMoveDirection();
    }
    
    private void OnMovementCanceled(InputAction.CallbackContext obj)
    {
        movementInput = Vector2.zero;
    }

    private void SetMoveDirection()
    {
        if (movementInput.x > 0)
        {
            moveDirection = Vector2.right;
        }
        if (movementInput.x < 0)
        {
            moveDirection = Vector2.left;
        }
        if (movementInput.y > 0) 
        {
            moveDirection = Vector2.up;
        }
        if (movementInput.y < 0)
        {
            moveDirection = Vector2.down;
        }
        Debug.Log(moveDirection);
    }
}