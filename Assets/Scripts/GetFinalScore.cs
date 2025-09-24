using TMPro;
using UnityEngine;

public class GetFinalScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreText;

    void Start()
    {
        if (GameSession.Instance != null && finalScoreText != null)
        {
            finalScoreText.text = "$" + GameSession.Instance.GetScore();
        }
        else
        {
            Debug.LogWarning("GameSession.Instance hoặc finalScoreText chưa được gán!");
        }
    }
}
