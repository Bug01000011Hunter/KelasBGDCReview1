using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float pushForce = 1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(1);
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            collision.GetComponent<Rigidbody2D>().AddForce(rb.velocity.normalized * pushForce, ForceMode2D.Impulse);
            Destroy(gameObject);
        }
    }
}
