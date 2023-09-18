using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Solution : MonoBehaviour
{
    public IObjectPool<GameObject> Pool { get; set; }
    public float speed = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.y > 5)
        {
            Pool.Release(gameObject);
        }

    }
}
