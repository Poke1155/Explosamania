using System;
using UnityEngine;
using static Explosion;

public static class BulletRaycast
{
    
    public static event Action<Transform> OnHit;
    public static void Shoot(Vector3 startPosition, Vector3 shootDirection)
    {
        RaycastHit2D hit = Physics2D.Raycast(startPosition, shootDirection);
        if (hit.collider != null)
        {
            //EventManager.OnExplosionTriggered(hit.point, new Vector2(5f, 5f));
            // Explosion.OnExplode?.Invoke(hit.point, new Vector2(5f, 5f));
        }
    }
}
