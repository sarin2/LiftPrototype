using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialPlatform : MonoBehaviour
{
    public float size;
    public float left, right;
    public GameObject Object;

    // Start is called before the first frame update
    void Start()
    {
        left = GetComponent<SpriteRenderer>().bounds.min.x;
        right = GetComponent<SpriteRenderer>().bounds.max.x;
        Debug.Log("Left : " + left + ", Right : " + right);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
