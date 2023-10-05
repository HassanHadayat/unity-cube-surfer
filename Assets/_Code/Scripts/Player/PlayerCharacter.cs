using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Hurdle"))
        {
            Time.timeScale = 0;
        }
        else if (collision.collider.CompareTag("Step"))
        {
            Time.timeScale = 0;
        }
    }
}
