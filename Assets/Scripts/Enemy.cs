using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageble
{
    [SerializeField] private float health;

    private float currentHealth;




    public virtual void Spawn(Vector3 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
    }

    public virtual void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0) Death();
    }

    public virtual void Death()
    {
        // spawn explosion
        gameObject.SetActive(false);
    }
}