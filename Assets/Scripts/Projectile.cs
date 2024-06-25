using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;

    private Rigidbody2D rb;




    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void FixedUpdate()
    {
        rb.MovePosition(rb.position + (speed * Time.fixedDeltaTime * Vector2.up));
        if (Mathf.Abs(rb.position.y) > 4.5f) gameObject.SetActive(false);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.TryGetComponent(out IDamageble target))
        {
            target.TakeDamage(damage);
            gameObject.SetActive(false);
        }
    }
}