using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class PlayerShootExplosive : MonoBehaviour
{
    private InputAction shoot;
    [SerializeField] private Transform pfBullet;
    [SerializeField] private GameObject explosion;
    private PlayerController player;
    private void OnEnable()
    { 
        PlayerInput playerInput = GetComponent<PlayerInput>();
        shoot = playerInput.actions["Shoot"];
        shoot.performed += OnShoot;
        player = GetComponent<PlayerController>();
    }

    // cannot shoot diagonally probably because its still insta switching based on which direction was last inputted?
    public void OnShoot(InputAction.CallbackContext context)
    {
        // Transform projectileTransform = Instantiate(pfBullet, player.castPosition.position, Quaternion.identity);
        Vector3 shootDir = player.FacingDirection;
        RaycastHit2D hit = Physics2D.Raycast(player.castPosition.position, shootDir);
        if (hit != null)
        {
            Instantiate(explosion, hit.point, Quaternion.identity);
        }
        // projectileTransform.GetComponent<Bullet>().Setup(shootDir);
    }

}
