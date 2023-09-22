using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Parallax : MonoBehaviour
{
    // Start is called before the first frame update

    public float length, startPos;
    public GameObject cam;
    public float horizontalSpeed;
    public float vericalSpeed;
    public CinemachineVirtualCamera virtualCamera;
    public CinemachineCameraOffset cameraOffset;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        virtualCamera = GameObject.FindGameObjectWithTag("VirtualCamera").GetComponent<CinemachineVirtualCamera>();
        cameraOffset = virtualCamera.GetComponent<CinemachineCameraOffset>();
    }

    private void FixedUpdate()
    {
        float xDist = (cam.transform.position.x * horizontalSpeed);
        float yDist = (cam.transform.position.y * vericalSpeed);

        transform.position = new Vector3(startPos + xDist, yDist + (cameraOffset.m_Offset.y/2), transform.position.z);
    }
}
