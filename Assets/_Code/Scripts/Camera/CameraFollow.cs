using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTrans;
    [SerializeField] private Vector3 offset;

    public float rotationSpeed = 1.5f;
    //private void LateUpdate()
    //{
    //    transform.LookAt(playerTrans);
    //    if (playerTrans)
    //    {
    //        transform.position = playerTrans.position + offset;
    //    }

    //}
    private void LateUpdate()
    {
        if (playerTrans == null) { return; }

        // Calculate the desired position behind the player.
        Vector3 targetPosition = playerTrans.position - playerTrans.forward * -offset.z + Vector3.up * offset.y;

        // Smoothly move the camera to the desired position.
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * rotationSpeed);

        // Rotate the camera to look away from the player.
        transform.LookAt(playerTrans.position);
    }
}
