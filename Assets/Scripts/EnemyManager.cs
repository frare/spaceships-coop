using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private ObjectPool asteroids;




    private void Awake()
    {
        StartCoroutine(EnemySpawning());
    }

    private IEnumerator EnemySpawning()
    {
        yield return new WaitForSeconds(1.5f);

        Enemy asteroid = asteroids.GetNext().GetComponent<Enemy>();
        asteroid.Spawn(new Vector3(Random.Range(-5f, 5f), 3.25f, 0f));

        StartCoroutine(EnemySpawning());
    }
}