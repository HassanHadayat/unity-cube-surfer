using UnityEngine;

public class Cube : MonoBehaviour
{
    public CubeStackManager CubeStackManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (transform.CompareTag("PlayerCube"))
        {
            if (collision.collider.CompareTag("Cube"))
            {
                // Player's Cube Collided With Collectable Cube
                collision.collider.gameObject.tag = "PlayerCube";
                // DeActivate Cube Game Object
                collision.collider.gameObject.SetActive(false);

                CubeStackManager.AddCube(collision.collider.gameObject);
            }
            else if (collision.collider.CompareTag("Hurdle") || collision.collider.CompareTag("Step"))
            {
                collision.collider.GetComponent<Collider>().enabled = false;

                collision.collider.tag = "Untagged";

                // Change tag from PlayerCube to Cube
                transform.tag = "Cube";

                CubeStackManager.RemoveCube(this.gameObject);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FinishLine"))
        {
            if (CubeStackManager)
            {
                CubeStackManager.GetComponent<PlayerMovement>().ReachFinishLine();
            }
        }
        
        if (other.CompareTag("FinalDest"))
        {
            if (CubeStackManager)
            {
                CubeStackManager.GetComponent<PlayerMovement>().ReachFinalDest();
            }
        }
    }

}
