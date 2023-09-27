using UnityEngine;

public class Cube : MonoBehaviour
{
    public CubeStackManager CubeStackManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (transform.CompareTag("Player"))
        {
            if (collision.collider.CompareTag("Cube"))
            {
                // Player's Cube Collided With Collectable Cube
                collision.collider.gameObject.tag = "Player";
                // DeActivate Cube Game Object
                collision.collider.gameObject.SetActive(false);

                //CubeStackManager.Add
                CubeStackManager.AddCube(collision.collider.gameObject);
            }
            else if (collision.collider.CompareTag("Hurdle"))
            {
                Debug.Log(transform.name);
                collision.collider.tag = "Untagged";

                // Change tag from Player to Cube
                transform.tag = "Cube";

                CubeStackManager.RemoveCube(this.gameObject);
            }
        }

    }

}
