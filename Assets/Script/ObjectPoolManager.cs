using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolManager : MonoBehaviour
{
    [SerializeField]
    private int capacity = 5;
    [SerializeField]
    private int maxPoolsize = 10;
    IObjectPool<GameObject> Pool { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Init()
    {

    }


}
