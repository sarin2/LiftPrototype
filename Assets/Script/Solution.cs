using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Solution : MonoBehaviour
{
    public IObjectPool<GameObject> Pool { get; set; }
    public float speed = 5f;
    public Rigidbody2D rigid;
    private float lifeTime = 2.0f;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        lifeTime = 2.0f;
    }

    void Update()
    {
        if (lifeTime <= 0)
        {
            Pool.Release(gameObject);
        }
        lifeTime -= Time.deltaTime;

    }
}
