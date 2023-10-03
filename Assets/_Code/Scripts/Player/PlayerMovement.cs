using PathCreation;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;
    public float horizontalLimit;

    public float maxX;
    public float minX;

    private Touch currTouch;

    private void LateUpdate()
    {
        if (Input.touchCount > 0)
        {
            currTouch = Input.GetTouch(0);

            if (currTouch.phase == TouchPhase.Moved)
            {

                float newX = currTouch.deltaPosition.x * horizontalSpeed * Time.deltaTime;
                Vector3 newPos = transform.localPosition;
                newPos.x += newX;
                newPos.x = Mathf.Clamp(newPos.x, minX, maxX);

                transform.localPosition = newPos;
            }
        }
    }
}
