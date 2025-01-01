using System;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private BoxCollider2D rb;
    private bool exploded = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (!exploded)
        {
            RaycastHit2D[] hits = Physics2D.BoxCastAll(this.transform.position, rb.size, 0f, Vector2.zero);
            foreach (RaycastHit2D hit in hits)
            {
                Debug.Log(hit.collider.gameObject.name);
            }
            Destroy(this.transform.parent.gameObject);
            exploded = true;
        }
    }
}
