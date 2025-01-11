using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10f;

    [SerializeField] private Transform upCastPosition;
    [SerializeField] private Transform downCastPosition;
    [SerializeField] private Transform rightCastPosition;
    [SerializeField] private Transform leftCastPosition;
    public Transform castPosition { get; private set;}
    
    private PlayerInput playerInput;
    private InputActionMap actionMap;
    private InputAction movement;
    public Vector2 MovementInput { get; private set; }
    public Vector2 FacingDirection {get; private set; }
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        movement = playerInput.actions["Movement"];
        movement.performed += OnMovement;
        movement.canceled += OnMovementCanceled;
        
    }
    

    private void FixedUpdate()
    {
        Vector3 movementValue = new Vector3(MovementInput.x, MovementInput.y, 0f);
        rb.MovePosition(transform.position + movementValue * movementSpeed * Time.fixedDeltaTime);
    }
    
    private void OnMovement(InputAction.CallbackContext context)
    {
        MovementInput = context.ReadValue<Vector2>();
        ChooseFacingDirection(MovementInput);
    }

    private void ChooseFacingDirection(Vector2 movementInput)
    {
        if (Math.Abs(movementInput.x) > Math.Abs(movementInput.y)) //choose x direction
        {
            FacingDirection = movementInput.x > 0 ? Vector2.right : Vector2.left;
            castPosition = movementInput.x > 0 ? rightCastPosition : leftCastPosition;
        }
        else // y direction
        {
            FacingDirection = movementInput.y > 0 ? Vector2.up : Vector2.down;
            castPosition = movementInput.y > 0 ? upCastPosition : downCastPosition;
        }
        // set animation here
    }

    private void OnMovementCanceled(InputAction.CallbackContext obj)
    {
        MovementInput = Vector2.zero;
    }
}