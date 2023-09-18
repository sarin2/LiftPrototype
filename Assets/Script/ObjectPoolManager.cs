using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolManager : MonoBehaviour
{
    [SerializeField]
    private int capacity = 500;
    [SerializeField]
    private int maxPoolSize = 1000;

    [SerializeField]
    public GameObject solutionPrefab;
    public ObjectPool<GameObject> Pool { get; set; }
    private void Awake()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Init()
    {
        Pool = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool,
        OnDestroyPoolObject, true, capacity, maxPoolSize);

        // �̸� ������Ʈ ���� �س���
        for (int i = 0; i < capacity; i++)
        {
            Solution bullet = CreatePooledItem().GetComponent<Solution>();
            bullet.Pool.Release(bullet.gameObject);
        }
    }


    // ����
    private GameObject CreatePooledItem()
    {
        GameObject poolGo = Instantiate(solutionPrefab);
        poolGo.GetComponent<Solution>().Pool = this.Pool;
        return poolGo;
    }

    // ���
    private void OnTakeFromPool(GameObject poolGo)
    {
        poolGo.SetActive(true);
    }

    // ��ȯ
    private void OnReturnedToPool(GameObject poolGo)
    {
        poolGo.SetActive(false);
    }

    // ����
    private void OnDestroyPoolObject(GameObject poolGo)
    {
        Destroy(poolGo);
    }


}
