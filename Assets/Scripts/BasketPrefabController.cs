using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketPrefabController : MonoBehaviour
{
    public float lifetime = 10f; // Prefab 存活时间

    void Start()
    {
        Invoke("Destroy", lifetime);
    }

    void Destroy()
    {
        if (gameObject)
        {
            Destroy(gameObject);
        }
    }
}
