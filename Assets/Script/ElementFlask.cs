using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;

public class ElementFlask : MonoBehaviour
{
    // Start is called before the first frame update

    public UnityEvent rechargeSyringe;
    public EElementType elementType;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKey(KeyCode.F))
        {
            rechargeSyringe.Invoke();
        }
    }
}
