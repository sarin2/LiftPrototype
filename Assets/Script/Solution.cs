using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Solution : MonoBehaviour
{
    public IObjectPool<GameObject> Pool { get; set; }
    public float speed = 5f;
    public Rigidbody2D rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
    }

    void Update()
    {
        if (transform.position.y > 5)
        {
            Pool.Release(gameObject);
        }
        else
        {
            rigid.AddForce(new Vector2(20, 20f));
        }

    }
}
