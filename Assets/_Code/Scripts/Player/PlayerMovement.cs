using PathCreation;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform m_bodyTrans;
    [SerializeField] private GameObject m_Trail;
    [SerializeField] private Animator m_Animator;


    [SerializeField] private float forwardSpeed;
    [SerializeField] private float horizontalSpeed;

    public float max_X;
    public float min_X;

    public PathCreator pathCreator;
    private float distanceTravelled;

    private Touch currTouch;
    private bool isReachedFinishLine = false;
    private bool isReachedFinalDest = false;

    void Update()
    {
        if (pathCreator != null && !isReachedFinishLine)
        {
            // Player Parent Follow Path
            distanceTravelled += forwardSpeed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, EndOfPathInstruction.Stop);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, EndOfPathInstruction.Stop);
        }
        else if (!isReachedFinalDest)
        {
            transform.position += transform.forward * forwardSpeed * Time.deltaTime;
        }
    }

    private void LateUpdate()
    {
        if (isReachedFinalDest) return;

        if (Input.touchCount > 0)
        {
            currTouch = Input.GetTouch(0);

            if (currTouch.phase == TouchPhase.Moved)
            {
                // Player Body Movement across Horizontal Axis

                float newX = currTouch.deltaPosition.x * horizontalSpeed * Time.deltaTime;
                Vector3 newPos = m_bodyTrans.localPosition;
                newPos.x += newX;
                newPos.x = Mathf.Clamp(newPos.x, min_X, max_X);

                m_bodyTrans.localPosition = newPos;
            }
        }
    }

    public void ReachFinishLine()
    {
        isReachedFinishLine = true;
        m_Trail.SetActive(false);
        m_Animator.Play("Running");
    }

    public void ReachFinalDest()
    {
        isReachedFinalDest = true;
        CameraManager.Instance.ChangeCamToRotate();

        m_Animator.SetTrigger("Dance");
    }
}
