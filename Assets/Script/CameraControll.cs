using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControll : MonoBehaviour
{
    CinemachineCameraOffset offset;
    Camera mainCamera;
    CinemachineVirtualCamera virtualCamera;
    CinemachineTransposer transposer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        virtualCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>();
        offset = GetComponent<CinemachineCameraOffset>();

        Debug.Log(offset.m_Offset.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
