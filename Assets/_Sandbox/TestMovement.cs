using PathCreation;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 5.0f; // Adjust the speed as needed.
    public float horizontalSpeed = 3.0f; // Adjust horizontal speed.

    private float distanceTravelled = 0f;

    private void Update()
    {
        // Move the player forward along the path.
        distanceTravelled += speed * Time.deltaTime;

        // Get the position on the path.
        Vector3 newPosition = pathCreator.path.GetPointAtDistance(distanceTravelled);
        Debug.Log(pathCreator.path.GetClosestPointOnPath(transform.position));
        // Update the player's position.
        transform.position = newPosition;

        // Handle horizontal movement (e.g., using Input).
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * horizontalSpeed * Time.deltaTime);
    }
}
