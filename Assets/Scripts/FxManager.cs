using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxManager : MonoBehaviour
{
    private static FxManager instance;

    [SerializeField] ObjectPool explosions;




    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public static void SpawnExplosion(Vector3 position)
    {
        GameObject explosion = instance.explosions.GetNext();
        explosion.transform.position = position;
    }
}