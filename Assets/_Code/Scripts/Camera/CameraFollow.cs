using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTrans;
    [SerializeField] private Vector3 offset;

    private void LateUpdate()
    {
        if (playerTrans)
        {
            transform.position = playerTrans.position + offset;
        }
    }

}
