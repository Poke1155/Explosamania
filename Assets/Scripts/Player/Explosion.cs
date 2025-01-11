using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Explosion : MonoBehaviour
{
    private PolygonCollider2D polygonCollider2D;
    // [SerializeField] private Vector2 size;
    private List<Collider2D> hits = new List<Collider2D>();
    private BoxCollider2D boxCollider2D;
    
    private void Start()
    {
        //boxCollider2D = GetComponent<BoxCollider2D>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        Explode();
    }

    private void Explode()
    {
        // rb.Overlap(this.transform.position, 0f, hits);
        Physics2D.OverlapCollider(polygonCollider2D, hits);
        foreach (var hit in hits)
        {
            Debug.Log(hit.gameObject.name);
            var damageable = hit.gameObject.GetComponent<IDamageable>();
            damageable?.TakeDamage(1);
        }
        StartCoroutine(DelayedDelete());
    }

    IEnumerator DelayedDelete()
    {
        yield return new WaitForSeconds(.2f);
        Destroy(this.gameObject);
    }
}