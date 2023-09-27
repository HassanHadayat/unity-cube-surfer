using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform playerTrans;
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float horizontalSpeed;
    public float horizontalLimit;

    private Vector2 touchStartPos;
    private Vector2 touchEndPos;

    private void Update()
    {
        // Move Forward
        playerTrans.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                touchEndPos = touch.position;
                HandleTouchInput();
            }
        }

        if (playerTrans.position.x > horizontalLimit)
        {
            playerTrans.position = new Vector3(horizontalLimit, playerTrans.position.y, playerTrans.position.z);
        }
        else if (playerTrans.position.x < -horizontalLimit)
        {
            playerTrans.position = new Vector3(-horizontalLimit, playerTrans.position.y, playerTrans.position.z);
        }
    }

    private void HandleTouchInput()
    {
        float horizontalInput = (touchEndPos.x - touchStartPos.x) / Screen.width;

        if (horizontalInput > 0)
        {
            // Move Rightward
            playerTrans.Translate(Vector3.right * horizontalSpeed * Time.deltaTime * horizontalInput);
        }
        else if (horizontalInput < 0)
        {
            // Move Leftward
            playerTrans.Translate(Vector3.left * horizontalSpeed * Time.deltaTime * -horizontalInput);
        }
    }
}
