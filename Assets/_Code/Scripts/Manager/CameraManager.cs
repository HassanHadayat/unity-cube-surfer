using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    [SerializeField] private CinemachineVirtualCamera followCam;
    [SerializeField] private CinemachineFreeLook rotateCam;

    [SerializeField] private float rotateSpeed = 20f;
    private bool isRotateCam = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        Application.targetFrameRate = Screen.currentResolution.refreshRate;
    }
    private void Start()
    {
        isRotateCam = false;
    }

    private void Update()
    {
        if (isRotateCam)
        {
            // Rotate Free Look Camera
            float rotationDelta = rotateSpeed * Time.deltaTime;
            rotateCam.m_XAxis.Value += rotationDelta;
        }
    }
    public void ChangeCamToRotate()
    {
        isRotateCam = true;

        rotateCam.Priority = 2;
        followCam.Priority = 1;
    }
}
