using UnityEngine;

public class Level : MonoBehaviour
{
    public LookPoint[] lookPoints;
    public Transform lookPositionsParent;


    private void Start()
    {
        lookPoints = lookPositionsParent.GetComponentsInChildren<LookPoint>();

        if (lookPoints.Length == 0 || lookPoints == null)
        {
            Debug.LogWarning("Look Position Transforms are not been set!");
        }
        else
        {
            for (int i = 0; i < lookPoints.Length - 1; i++)
            {
                Debug.Log(lookPoints[i].name);
                lookPoints[i].nextLookPoint = lookPoints[i + 1].transform;
            }
        }
    }


}
