using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Player : MonoBehaviour, IDamageble
{
    public int Id { get => id; }
    public Vector2 Position { get => rb.position; }

    [SerializeField] private int id;
    [SerializeField] private float speed;
    private Vector2 movement;

    [SerializeField] ObjectPool bullets;
    private Rigidbody2D rb;
    private Animator animator;





    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();

        animator.SetFloat("movement", movement.x);
    }
    
    private void Move()
    {
        if (id == 1)
        {
            movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        }
        else
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = mousePosition - rb.position;
            if (direction.magnitude > 0.01f) movement = direction.normalized;
            else movement = Vector2.zero;
            
        }

        rb.position += speed * Time.deltaTime * movement;
    }

    public void TakeDamage(int damage)
    {
        
    }
}