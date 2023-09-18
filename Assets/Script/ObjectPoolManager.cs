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

        // 미리 오브젝트 생성 해놓기
        for (int i = 0; i < capacity; i++)
        {
            Solution bullet = CreatePooledItem().GetComponent<Solution>();
            bullet.Pool.Release(bullet.gameObject);
        }
    }


    // 생성
    private GameObject CreatePooledItem()
    {
        GameObject poolGo = Instantiate(solutionPrefab);
        poolGo.GetComponent<Solution>().Pool = this.Pool;
        return poolGo;
    }

    // 사용
    private void OnTakeFromPool(GameObject poolGo)
    {
        poolGo.SetActive(true);
    }

    // 반환
    private void OnReturnedToPool(GameObject poolGo)
    {
        poolGo.SetActive(false);
    }

    // 삭제
    private void OnDestroyPoolObject(GameObject poolGo)
    {
        Destroy(poolGo);
    }


}
