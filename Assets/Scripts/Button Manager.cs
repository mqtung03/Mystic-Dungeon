using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] string firstLevelName = "Level 0"; // Scene đầu tiên khi New Game

    // Gọi khi nhấn New Game
    public void NewGame()
    {
        // Reset lại GameSession nếu đang dùng singleton
        GameSession gameSession = FindFirstObjectByType<GameSession>();
        if (gameSession != null)
        {
            Destroy(gameSession.gameObject);
        }

        SceneManager.LoadScene(firstLevelName);
    }

    // Gọi khi nhấn Exit
    public void ExitGame()
    {
        Debug.Log("Thoát game");
        Application.Quit();
    }
}
