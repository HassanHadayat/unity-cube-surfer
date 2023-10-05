using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public void OnClick_Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
