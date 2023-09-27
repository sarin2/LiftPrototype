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
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        virtualCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>();
        offset = GetComponent<CinemachineCameraOffset>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
