using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyAsteroid : Enemy
{
    [SerializeField] private float speed;
    [SerializeField] private List<Sprite> sprites;

    private Vector2 direction;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;





    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        rb.position += speed * Time.deltaTime * direction;
    }

    public override void Spawn(Vector3 position)
    {
        base.Spawn(position);

        Player target = FindObjectsOfType<Player>()[Random.Range(0, 2)];
        if (target == null) return;

        direction = (target.Position - rb.position).normalized;
        transform.localEulerAngles = new Vector3(0f, 0f, Random.Range(-180f, 180f));
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Count)];
    }

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
    }

    public override void Death()
    {
        base.Death();
    }
}