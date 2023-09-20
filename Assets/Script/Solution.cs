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

    private void Awake()
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
            rigid.gravityScale = 0f;
            Pool.Release(gameObject);
        }
        lifeTime -= Time.deltaTime;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name.Contains("Wall"))
        rigid.gravityScale = 2.0f;
    }
}
