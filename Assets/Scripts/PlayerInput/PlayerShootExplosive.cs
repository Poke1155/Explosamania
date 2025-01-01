using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class PlayerShootExplosive : MonoBehaviour
{
    private InputAction shoot;
    [SerializeField] private Transform pfBullet;
    private void OnEnable()
    { 
        PlayerInput playerInput = GetComponent<PlayerInput>();
        shoot = playerInput.actions["Shoot"];
        shoot.performed += OnShoot;
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        Transform projectileTransform = Instantiate(pfBullet, transform.position, Quaternion.identity);
        Vector3 shootDir = (transform.position - projectileTransform.position).normalized;
        projectileTransform.GetComponent<Bullet>().Setup(shootDir);
    }

}
