using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinSound;
    [SerializeField] int pointsForCoinPickup = 100;
    bool hasBeenCollected = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !hasBeenCollected)
        {
            hasBeenCollected = true;
            FindFirstObjectByType<GameSession>().AddToScore(pointsForCoinPickup);
            AudioSource.PlayClipAtPoint(coinSound, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
