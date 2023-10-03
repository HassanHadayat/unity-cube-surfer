using UnityEngine;

public class LookPoint : MonoBehaviour
{
    public Transform nextLookPoint;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player Pass through this Point

            // Set the Player's next Look Point
            if (nextLookPoint != null)
            {
                //other.GetComponent<PlayerMovement>().lookTrans_a = transform;
                //other.GetComponent<PlayerMovement>().lookTrans = nextLookPoint;
            }
        }
    }
}
