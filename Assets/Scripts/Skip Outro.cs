using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipOutro : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Level 0", LoadSceneMode.Single);
    }
}
