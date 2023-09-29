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
    [SerializeField]
    private List<GameObject> distantView;

    private float camHeight;
    private float camWdith;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    private void Awake()
    {
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        offset = GetComponent<CinemachineCameraOffset>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float scrollValue = (Input.mouseScrollDelta.y * 0.1f);
        virtualCamera.m_Lens.OrthographicSize -= scrollValue;
        offset.m_Offset.y += -(scrollValue);
        camHeight = 2f * mainCamera.orthographicSize;
        camWdith = camHeight * mainCamera.aspect;

        Vector2 imageSize = new Vector2(camWdith+0.5f, camHeight+0.3f);

        for(int i = 0; i < distantView.Count; i++)
        {
            distantView[i].GetComponent<SpriteRenderer>().size = imageSize;
            distantView[i].transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, -5f);
        }

            }
}
