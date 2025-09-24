using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadFirstScene : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
    }
}
