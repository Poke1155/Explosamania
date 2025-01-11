using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{
    private InputAction shoot;

    private Vector3 shootDir;
    
    [SerializeField] private GameObject explosion;

    [SerializeField] private float speed = 50f;
    
    public event Action OnExplode;

    // Fix shoot direction, only take whatever direction the player is facing for impl?
    public void Setup(Vector3 shootDir)
    {
        this.shootDir = shootDir;
        // transform.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(shootDir));
        Destroy(this.gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += shootDir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // is Iexplodable interface actually useful for anything?
        // should the collision be generalized, and explosions just be a part of it?
        // trigger explosion
        // sometimes hits player?? i know why idk an elegane solution to this lol
        Instantiate(explosion, this.transform.position, transform.rotation);
        // EventManager.OnExplosionTriggered?.Invoke(this.transform.position, new Vector2(5f, 5f));
        // OnExplode?.Invoke();
        Destroy(gameObject);
    }

    
    // probably don't need this, we should probably use this to default to some direction that the player is facing no? what the fuck? sigma balls in my nuts? peanits?
    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }
}
